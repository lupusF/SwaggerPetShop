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
    public class AddPetService : ServiceBase, IAddPetService
    {
        public async Task<ReturnPetWithResponse> AddPet(Pet item)
        {
            var url = ConfigurationManager.AppSettings["AddPetUrl"];
            var jsonbody = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonbody, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api_key", apiKey);
                var result = client.PostAsync(url, content).Result;
                return new ReturnPetWithResponse
                {
                    Message = result.ReasonPhrase
                };
            }
        }

        Pet createDummyPet()
        {
            return new Pet()
            {
                category = new Category()
                {
                    id = 1,
                    name = "name"
                },
                id = 123,
                name = "adfs",
                photoUrls = new List<string>()
                     {
                          "1", "2"
                     },
                status = "available",
                tags = new List<Tag>()
                       {
                            new Tag()
                            {
                                 name = "name",
                                  id  = 2
                            }
                       }


            };
        }

       
    }
}
