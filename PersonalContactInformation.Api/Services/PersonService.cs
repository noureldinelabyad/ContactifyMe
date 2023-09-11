﻿using Microsoft.EntityFrameworkCore;
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

            // var chk = await appDbContext.People.Where(p => p.Nachname.ToLower().Equals(person.Nachname.ToLower())).FirstOrDefaultAsync();
            // 
            // if (chk is null)
            // {
            appDbContext.People.Add(person);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Contact added", Success = true };
            // }
            // return new ServiceResponse() { Message = "Contact already added", Success = false };
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
            var person = await appDbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            return person!;
        }

        public async Task<List<Person>> GetPersonsAsync() => await appDbContext.People.ToListAsync();

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
            UpdateTelefonnummerAsync(result, result.TelId, person.TelId);
            // result.Telefonnummer = person.Telefonnummer; // line above shold do this when that function is implemented
            result.EMail = person.EMail;
            result.Strasse = person.Strasse;
            result.Hausnummer = person.Hausnummer;
            result.PLZ = person.PLZ;
            result.Stadt = person.Stadt;
            result.Land = person.Land;
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Contact updated", Success = true };
        }

        public async Task<ServiceResponse> AddPersonJSONAsync(string jsonContent, UpdateStrategy strategy)
        {
            List<Person> toBeInserted = new List<Person>();                                                              // helper for converting and input
            toBeInserted = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(jsonContent);                     // formating "raw JSON string"
            bool isAnyDuplicates = false;
            foreach (var person in toBeInserted)                                                                         // going until we went through the whole list
            {
                var dbItem = await appDbContext.People.FirstOrDefaultAsync(p => p.Nachname == person.Nachname && p.Vorname == person.Vorname); // checking if first and last name already exists in db
                isAnyDuplicates = isAnyDuplicates || dbItem != null;                                                     // if the flag is true and/or dbitem is not null, set flag to true
                
                if (dbItem != null)
                {
                    switch (strategy)                                                                                    // switch case depending on what the user wants to do with the JSON File in case of duplicates
                    {
                        case UpdateStrategy.Skip:                                                                        // skipping over elements which are duplicates
                            break;
                        case UpdateStrategy.Merge:                                                                       // merginig "old" data of duplicate elements with "new" data from JSON file excluding names, since they are technically the identifier
                            // TODO merge info in multivalue case
                            dbItem.PLZ = person.PLZ;
                            dbItem.Stadt = person.Stadt;
                            dbItem.Land = person.Land;
                            AddTelefonnummerAsync(dbItem, newNumber); // this doesn't work, ask reza about this on monday, i might get it to work, i will ask him anyways :]
                            // dbItem.Telefonnummer = person.Telefonnummer;
                            dbItem.Hausnummer = person.Hausnummer;
                            dbItem.EMail = person.EMail;

                            await this.appDbContext.SaveChangesAsync();

                            break;
                        case UpdateStrategy.Replace:                                                                     // updating data in table with new data from JSON file excluding names, since they are technically the identifier
                            dbItem.PLZ = person.PLZ;
                            dbItem.Stadt = person.Stadt;    
                            dbItem.Land = person.Land;
                            dbItem.Telefonnummer    = person.Telefonnummer;
                            dbItem.Hausnummer   = person.Hausnummer;
                            dbItem.EMail = person.EMail;

                            await this.appDbContext.SaveChangesAsync();

                            break;
                        default:
                            throw new InvalidOperationException();                                                       // since this case should not actually happen, something went wrong and we throw an exception instead of letting the progam run wild
                    }
                }
                else
                {
                    person.Id = 0;                                                                                       // setting id to 0 will make sql assign a new id (working around id being used in input)
                    await AddPersonAsync(person);
                }

            }
            if (isAnyDuplicates == true)                                                                                       
            {
                return new ServiceResponse() { Message = "Done, there were one or more duplicate contacts", Success = true };// not completely necessary but sending a msg if we had duplicates for completions sake
            }
            else
            {
                return new ServiceResponse() { Message = "Done", Success = true };
            }
        }

        public async Task<ServiceResponse> AddTelefonnummerAsync(Person person, string newNumber)
        {
            /*
            var helperJuan = person.Id;
            var dbItem = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.PersonId == helperJuan && p.TelNummer == newNumber);
            if (dbItem != null) 
            {
                return new ServiceResponse() { Message = "Number already saved", Success = false };
            }

            newNumberWhoDis = new Telefonnummer;
            newNumberWhoDis.PersonId = person.Id;
            newNumberWhoDis.TelNummer = newNumber;

            appDbContext.TelNr.Add(newNumberWhoDis);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Number added", Success = true };
            */
        }

        public async Task<ServiceResponse> DeleteTelefonnummerAsync(Person person, string deleteNumber)
        {
            /*
            var helperCarlos = person.Id;
            var dbItem = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.PersonId == helperCarlos && p.TelNummer == deleteNumber);   // i need this but it returns a item instead
            if (dbItem == null)
            {
                return new ServiceResponse() { Message = "Number does not exist", Success = false };
            }

            appDbContext.TelNr.Remove(deleteThis);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Number deleted", Success = true };
             */
        }

        public async Task<ServiceResponse> UpdateTelefonnummerAsync(Person person, string oldNumber, string newNumber)
        {
            // should take a person object or just personId, a already existing phone number and a new phone number
            // should fetch the table entry which matches both the personId and the old phone number, then replace it
            /*
            var helperJoaquin = person.Id;
            var dbItem = await appDbContext.TelNr.FirstOrDefaultAsync(p => p.PersonId == helperJoaquin && p.TelNummer == oldNumber);
            if (dbItem == null)
            {
                return new ServiceResponse() { Message = "Number not found", Success = false };
            }
            var replaceThis = findTheNumberInTheTableFunction.TelNr();
            replaceThis.TelNummer = newNumber;

            */
        }
    }
}
