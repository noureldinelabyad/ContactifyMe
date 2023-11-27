using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PersonalContactInformation.Api.Data;
using PersonalContactInformation.Library.Models;
using PersonalContactInformation.Library.Responses;
using System.Net.Http.Headers;

namespace PersonalContactInformation.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext appDbContext;

        public PersonService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> AddPersonAsync(Person person)
        {
            if (person == null)
            {
                return new ServiceResponse() { Message = "Bad Request", Success = false };
            }

            foreach (var nummer in person.PersonNummern)
            {
                nummer.Id = 0;
            }

            appDbContext.People.Add(person);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Contact added", Success = true };
        }

        public async Task<ServiceResponse> DeletePersonAsync(int id)
        {
            var person = await appDbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                return new ServiceResponse() { Message = "Contact not found", Success = false };
            }

            appDbContext.People.Remove(person);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Contact deleted", Success = true };
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var person = await appDbContext.People
                                    .Include(p => p.PersonNummern)
                                    .FirstOrDefaultAsync(p => p.Id == id);  
            return person!;
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            return await appDbContext.People.Include(p => p.PersonNummern/*‾\_('-' )__/‾*/).ToListAsync();
        }

        public async Task<ServiceResponse> UpdatePersonAsync(Person person)
        {
            var result = await appDbContext.People.FirstOrDefaultAsync(p => p.Id == person.Id);
            if (result == null)
            {
                return new ServiceResponse() { Message = "Contact not found", Success = false };
            }

            result.Nachname = person.Nachname;
            result.Vorname = person.Vorname;
            result.Zwischenname = person.Zwischenname;
            
            await  ReplaceTelefonnummerAsync(person, person.PersonNummern);

            result.EMail = person.EMail;
            result.Strasse = person.Strasse;
            result.Hausnummer = person.Hausnummer;
            result.PLZ = person.PLZ;
            result.Stadt = person.Stadt;
            result.Land = person.Land;
            result.Gender = person.Gender;
            
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Contact updated", Success = true };
        }

        public async Task<ServiceResponse> AddPersonJSONAsync(string jsonContent, UpdateStrategy strategy )
        {

            List<Person> toBeInserted = new List<Person>();                                                              // helper for converting and input
            toBeInserted = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(jsonContent);                     // formating "raw JSON string"
            List<Telefonnummer> toBeInsertedTel = new List<Telefonnummer>();
            bool isAnyDuplicates = false;
            foreach (var person in toBeInserted)
            {
                var dbItem = await appDbContext.People.FirstOrDefaultAsync(p => p.Nachname == person.Nachname && p.Vorname == person.Vorname); // check for duplicates
                isAnyDuplicates = isAnyDuplicates || dbItem != null;                                                     // flag for duplicates
                
                if (dbItem != null)
                {
                    switch (strategy)                                                                                    // switch case depending on what the user wants to do with the JSON File in case of duplicates
                    {                                                                                                    // choice is based on passed-in "update strategy" property
                        case UpdateStrategy.Skip:                                                                        // skipping over elements which are duplicates
                            break;

                        case UpdateStrategy.MergeSkip:
                            foreach (var nummer in person.PersonNummern)                                                 // merginig "old" data of duplicate elements with "new" data from JSON file, skipping over old data and numbers which already exist
                            {
                                await AddTelefonnummerAsync(dbItem, nummer.TelNummer);
                            }

                            await this.appDbContext.SaveChangesAsync();

                            break;
                        
                        case UpdateStrategy.MergeReplace:                                                                // merginig "old" data of duplicate elements with "new" data from JSON file, overriding the old data in case there were changes
                            dbItem.Nachname = person.Nachname;
                            dbItem.Vorname = person.Vorname;
                            if (person.Zwischenname != null)
                            {
                                dbItem.Zwischenname = person.Zwischenname;
                            }
                            dbItem.EMail = person.EMail;
                            dbItem.Strasse = person.Strasse;
                            dbItem.Hausnummer = person.Hausnummer;
                            dbItem.PLZ = person.PLZ;
                            dbItem.Stadt = person.Stadt;
                            dbItem.Land = person.Land;
                            dbItem.Gender = person.Gender;
                            foreach (var nummer in person.PersonNummern)
                            {
                                await AddTelefonnummerAsync(dbItem, nummer.TelNummer);
                            }

                            await this.appDbContext.SaveChangesAsync();

                            break;

                        case UpdateStrategy.Replace:                                                                     // updating data in table with new data from JSON file
                            dbItem.Nachname = person.Nachname;
                            dbItem.Vorname = person.Vorname;
                            if(person.Zwischenname != null)
                            {
                                dbItem.Zwischenname = person.Zwischenname;
                            }
                            dbItem.EMail = person.EMail;
                            dbItem.Strasse = person.Strasse;
                            dbItem.Hausnummer   = person.Hausnummer;
                            dbItem.PLZ = person.PLZ;
                            dbItem.Stadt = person.Stadt;    
                            dbItem.Land = person.Land;
                            dbItem.Gender = person.Gender;
                            foreach (var nummer in person.PersonNummern)
                            {
                                await ReplaceTelefonnummerAsync(dbItem, toBeInsertedTel);
                            }

                            await this.appDbContext.SaveChangesAsync();

                            break;

                        case UpdateStrategy.Update:
                            
                            if (dbItem.Zwischenname != person.Zwischenname)
                            {
                                dbItem.Zwischenname = person.Zwischenname;
                            }

                            if (dbItem.EMail != person.EMail)
                            {
                                dbItem.EMail = person.EMail;
                            }

                            if (dbItem.Strasse != person.Strasse)
                            {
                                dbItem.Strasse = person.Strasse;
                            }

                            if (dbItem.Hausnummer != person.Hausnummer)
                            {
                                dbItem.Hausnummer = person.Hausnummer;
                            }

                            if (dbItem.PLZ != person.PLZ)
                            {
                                dbItem.PLZ = person.PLZ;
                            }

                            if (dbItem.Stadt != person.Stadt)
                            {
                                dbItem.Stadt = person.Stadt;
                            }

                            if (dbItem.Land != person.Land)
                            {
                                dbItem.Land = person.Land;
                            }

                            if (dbItem.Gender != person.Gender)
                            {
                                dbItem.Gender = person.Gender;
                            }

                            foreach (var nummer in person.PersonNummern)
                            {
                                await AddTelefonnummerAsync(dbItem, nummer.TelNummer);
                            }

                            await this.appDbContext.SaveChangesAsync();
                            
                            break;

                        default:
                            throw new InvalidOperationException();                                                       // since this case should not actually happen, something went wrong and we throw an exception instead of letting the progam run wild
                    }
                }
                else
                {
                    person.Id = 0;                                                                                       // setting id to 0 will make sql assign a new id (which is required especially if there already are db entries)
                    await AddPersonAsync(person);
                }


            }
            if (isAnyDuplicates == true)                                                                                 // not completely necessary but sending a msg if there is duplicate data (option for frontend)
            {
                return new ServiceResponse() { Message = "Done, there were one or more duplicate contacts", Success = true };
            }
            else
            {
                return new ServiceResponse() { Message = "Done", Success = true };
            }
        }

        public async Task<ServiceResponse> AddTelefonnummerAsync(Person person, string newNumber)
        {
            var dbItem = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.PersonId == person.Id && p.TelNummer == newNumber);
            if (dbItem != null) 
            {
                return new ServiceResponse() { Message = "Number already saved", Success = false };
            }

            Telefonnummer newNumberWhoDis = new Telefonnummer();
            newNumberWhoDis.Id = 0;
            newNumberWhoDis.PersonId = person.Id;
            newNumberWhoDis.TelNummer = newNumber;

            appDbContext.TelNr.Add(newNumberWhoDis);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Number added", Success = true };
        }

        public async Task<Telefonnummer> GetTelefonnummerByIdAsync(int id)
        {
            var telefonnummer = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.Id == id);
            return telefonnummer!;
        }

        public async Task<ServiceResponse> DeleteTelefonnummerAsync(Person person, string deleteNumber)
        {
            var dbItem = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.PersonId == person.Id && p.TelNummer == deleteNumber);
            if (dbItem == null)
            {
                return new ServiceResponse() { Message = "Number does not exist", Success = false };
            }

            appDbContext.TelNr.Remove(dbItem);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Number deleted", Success = true }; 
        }

        public async Task<ServiceResponse> UpdateTelefonnummerAsync(Person person, string oldNumber, string newNumber)
        {
            var dbItem = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.PersonId == person.Id && p.TelNummer == oldNumber);
            if (dbItem == null)
            {
                return new ServiceResponse() { Message = "Number not found", Success = false };
            }
            else if (oldNumber == newNumber)
            {
                return new ServiceResponse() { Message = "New and old number identical", Success = false };
            }

            dbItem.TelNummer = newNumber;
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Number updated", Success = true };
        }

        public async Task<ServiceResponse> ReplaceTelefonnummerAsync(Person person, List<Telefonnummer> newTelefonnummern)
        {
            List<Telefonnummer> helperList = new List<Telefonnummer>();
            helperList = appDbContext.TelNr.ToList();
            
            foreach (var telNr in helperList)
            {
                if (telNr != null && telNr.PersonId == person.Id)
                {
                    appDbContext.TelNr.Remove(telNr);
                    await appDbContext.SaveChangesAsync();
                }
            }

            int index = 0;
            foreach (var telNr in newTelefonnummern)
            {
                await AddTelefonnummerAsync(person, newTelefonnummern[index].TelNummer);
                index++;
            }
            
            return new ServiceResponse() { Message = "Numbers replaced", Success = true };
        }
    }
}
