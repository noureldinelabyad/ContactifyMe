using CommonCode.Models;
using CommonCode.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonCode.Services
{
    public interface IPersonService
    {

        Task<List<PersonModel>> GetAllPersonsList();
        Task<MainResponseModel> AddPerson(AddUpdatePersonRequest personRequest);
        Task<MainResponseModel> UpdatePerson(AddUpdatePersonRequest personRequest);
        //Task<MainResponseModel> DeletePerson(AddUpdatePersonRequest personRequest);
        Task<MainResponseModel> DeletePerson(int Id);

        Task<PersonModel> GetPersonDetailById(int Id);
        Task<MainResponseModel> AddPhoneNumber(int personId, string newNumber);
        Task<MainResponseModel> UpdatePhoneNumber(int personId, string oldNumber, string newNumber);
        Task<MainResponseModel> DeletePhoneNumber(int personId, string deleteNumber);



    }


}
