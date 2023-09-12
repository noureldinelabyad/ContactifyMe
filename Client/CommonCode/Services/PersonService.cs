using CommonCode.Models;
using CommonCode.Models.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;



namespace CommonCode.Services
{

    public class PersonService : IPersonService
    {
        private string _baseUrl = "https://localhost:7078"; // URL of the API database

        public async Task<MainResponseModel> AddPerson(AddUpdatePersonRequest personRequest)
        {
            var returnResponse = new MainResponseModel();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Persons/Add";
                    
                    var seralizeContent = JsonConvert.SerializeObject(personRequest);

                    // var apiResponse = await client.PostAsync(url, new StringContent(seralizeContent, Encoding.UTF8, "application/json"));
                    var apiResponse = await client.PostAsync(url, JsonContent.Create(personRequest, personRequest.GetType()));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<MainResponseModel>(response);
                    }
                }
            }
            catch (WebException ex)
            {
                // Log or handle the exception gracefully.
                string Msg = ex.Message;
                var sr = new StreamReader(ex.Response.GetResponseStream());
                var result = sr.ReadToEnd();
                sr.Close();
                // You might also consider rethrowing the exception if you want to propagate it further.
            }
            catch (Exception ex)
            {
                // Log or handle the exception gracefully.
                string Msg = ex.Message;
                // You might also consider rethrowing the exception if you want to propagate it further.
            }
            return returnResponse;
        }


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
                        returnResponse = JsonConvert.DeserializeObject<List<PersonModel>>(response);


                    }

                    foreach (var person in returnResponse)

                    {

                        // var zwischennameHelper = await returnResponse.person.FirstOrDefaultAsync(p => p.Zwischenname == null);


                        // if (zwischennameHelper == null)

                        if (person.Zwischenname == null)
                        {

                            person.Zwischenname = " ";

                        }

                                            

                        if (person.Gender == null)
                        {

                            person.Gender = " ";

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception gracefully.
                string Msg = ex.Message;
                // You might also consider rethrowing the exception if you want to propagate it further.
            }
            return returnResponse;
        }


        public async Task<PersonModel> GetPersonDetailById(int Id)
        {
            var returnResponse = new PersonModel();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Persons/{Id}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponse = JsonConvert.DeserializeObject<PersonModel>(response);


                    }

                    

                    

                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception gracefully.
                string Msg = ex.Message;
                // You might also consider rethrowing the exception if you want to propagate it further.
            }
            return returnResponse;
        }

        public async Task<MainResponseModel> DeletePerson (AddUpdatePersonRequest personRequest )
        {
            var returnresponse = new MainResponseModel();

            try
            {

                using (var client = new HttpClient())
                {
                    //string url = $"{_baseUrl}/api/Persons/Delete";
                    string url = $"{_baseUrl}/api/Persons/{personRequest.Id}";



                    var serializeContent = JsonConvert.SerializeObject(personRequest);

                    var request = new HttpRequestMessage();

                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiresponse = await client.SendAsync(request);


                    if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiresponse.Content.ReadAsStringAsync();
                        returnresponse = JsonConvert.DeserializeObject<MainResponseModel>(response);
                    }

                }
            }

            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return returnresponse;
        }
        

        public async Task<MainResponseModel> UpdatePerson(AddUpdatePersonRequest personRequest)
        {
            var returnresponse = new MainResponseModel();

            
            try
            {

                using (var client = new HttpClient())
                {
                   // string url = $"{_baseUrl}/api/Persons/Update";
                    string url = $"{_baseUrl}/api/Persons/{personRequest.Id}";


                    var serializeContent = JsonConvert.SerializeObject(personRequest);
                    var apiresponse = await client.PutAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));
                    if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiresponse.Content.ReadAsStringAsync();
                        returnresponse = JsonConvert.DeserializeObject<MainResponseModel>(response);
                    }

                }
            }

            catch (Exception ex)
            { 
                string msg = ex.Message;
            }
            return returnresponse;
        }

        
    }
    
}
