using MauiBlazorApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MauiBlazorApp.Services
{
    public class PersonService : IPersonService
    {
        private  string _baseUrl = "https://localhost:7078"; // URL of the API database



        public async Task<List<PersonModel>> GetAllPersonsList()
        {
            var returnResponse = new List<PersonModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Persons";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        var deserilizeResponse = JsonConvert.DeserializeObject<List<PersonModel>>(response);

                        return deserilizeResponse;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception gracefully.
                string errorMsg = ex.Message;
                // You might also consider rethrowing the exception if you want to propagate it further.
            }
            return returnResponse;
        }
    }
}
