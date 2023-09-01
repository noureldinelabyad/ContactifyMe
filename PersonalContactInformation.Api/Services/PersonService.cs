using Microsoft.EntityFrameworkCore;
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

            var chk = await appDbContext.People.Where(p => p.Nachname.ToLower().Equals(person.Nachname.ToLower())).FirstOrDefaultAsync();

            if(chk is null)
            {
                appDbContext.People.Add(person);
                await appDbContext.SaveChangesAsync();
                return new ServiceResponse() { Message = "Contact already added", Success = true };
            }
                return new ServiceResponse() { Message = "Contact already added", Success = false };
        }

        public async Task<ServiceResponse> DeletePersonAsync(int id)
        {
            var person = await appDbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if(person == null)
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
            if(result == null)
            {
                return new ServiceResponse() { Message = "Contact not found", Success = false };
            }

            result.Nachname = person.Nachname;
            result.Vorname = person.Vorname;
            result.Zwischenname = person.Zwischenname;
            result.Telefonnummer = person.Telefonnummer;
            result.EMail = person.EMail;
            result.Straße = person.Straße;
            result.Hausnummer = person.Hausnummer;
            result.PLZ = person.PLZ;
            result.Stadt = person.Stadt;
            result.Land = person.Land;
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse() { Message = "Contact updated", Success = true };
        }
    }
}
