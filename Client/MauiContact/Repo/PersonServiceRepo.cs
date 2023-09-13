using MauiContact.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiContact.Repo
{
    public class PersonServiceRepo : IPersonRepo
    {
        public async Task<PersonModel> GetAllPersonsList()
        {
            var cleint = new HttpClient();

            string url = "https://localhost:7078/api/Persons";

            cleint.BaseAddress = new Uri(url);

            HttpResponseMessage response = await cleint.GetAsync(cleint.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                PersonModel person = JsonConvert.DeserializeObject<PersonModel>(content);
                return await Task.FromResult   (person);
            }
            
            return null;
        }
    }
}
