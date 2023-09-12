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
        Task<MainResponseModel> DeletePerson(AddUpdatePersonRequest personRequest );
        Task<PersonModel> GetPersonDetailById(int Id);
    }
}
