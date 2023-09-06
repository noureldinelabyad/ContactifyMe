using MauiBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiBlazorApp.Services
{
    public interface IPersonService
    {

        Task<List<PersonModel>> GetAllPersonsList();
    }
}
