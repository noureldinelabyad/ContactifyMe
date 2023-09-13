using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiContact.Models;
using MauiContact.Services;


namespace MauiContact.Repo
{
   public  interface IPersonRepo
    {
       Task<PersonModel> GetAllPersonsList();  

    }
}
