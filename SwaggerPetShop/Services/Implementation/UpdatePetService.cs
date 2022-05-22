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
    public class UpdatePetService : IUpdatePetService
    {
        private const string URL = "https://petstore.swagger.io/v2/pet";
        private const string API_KEY = "special-key";
        public async Task<bool> UpdatePet(Pet item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api_key", "special-key");

                var jsonBody = JsonConvert.SerializeObject(item);

                HttpContent cont = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(URL, cont).Result;
                if (response.IsSuccessStatusCode)
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

