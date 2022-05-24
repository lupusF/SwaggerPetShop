using Newtonsoft.Json;
using SwaggerPetShop.DTOs;
using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Implementation
{
    public class GetByIdService : ServiceBase, IGetByIdService
    {
        public async Task<ReturnPetWithResponse> GetById(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var url = ConfigurationManager.AppSettings["GetByIdUrl"];
                    client.DefaultRequestHeaders.Add("api-key", apiKey);
                    HttpResponseMessage response = client.GetAsync($"{url}{id}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responsetring = await response.Content.ReadAsStringAsync();

                        var pet = JsonConvert.DeserializeObject<Pet>(responsetring);

                        return new ReturnPetWithResponse
                        {
                            Pet = pet,
                            Message = response.ReasonPhrase,
                        };
                    }
                    else
                    {
                        return new ReturnPetWithResponse
                        {
                            Message = response.ReasonPhrase,
                        };
                    }
                }
                catch (Exception exception)
                {
                    return new ReturnPetWithResponse
                    {
                        Message = exception.Message
                    };
                }
            }
        }
    }
}
