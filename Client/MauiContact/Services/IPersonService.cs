using MauiContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiContact.Services
{
    public interface IPersonService
    {

        Task<List<PersonModel>> GetAllPersonsList();

        Task<MainResponseModel> AddPerson(AddUpdatePersonRequest personRequest);
        Task<MainResponseModel> UpdatePerson(AddUpdatePersonRequest personRequest);
        Task<MainResponseModel> DeletePerson(AddUpdatePersonRequest personRequest );
        Task<PersonModel> GetPersonDetailById(int Id);
    }
}
