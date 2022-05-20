using Newtonsoft.Json;
using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Implementation
{
    public class AddPetService : IAddPetService
    {
        private const string URL = "petstore.swagger.io/v2/pet";
        private const string API_KEY = "special-key";
        public async Task<bool> AddPet(Pet item)
        {
            var jsonbody = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonbody, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api_key", API_KEY);
                var result = await client.PostAsync(URL, content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

       
    }
}
