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
    public class GetByIdService : IGetByIdService
    {
        private const string URL2 = "https://petstore.swagger.io/v2/pet/";

        public async Task<Pet> GetById(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api-key", "special-key");
                HttpResponseMessage response = client.GetAsync($"{URL2}{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responsetring = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<Pet>(responsetring);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
