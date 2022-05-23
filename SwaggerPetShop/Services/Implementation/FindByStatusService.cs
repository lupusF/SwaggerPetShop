using Newtonsoft.Json;
using SwaggerPetShop.Model;
//using SwaggerPetShop.Model;
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
    public class FindByStatusService : IFindByStatusService
    {
        //private const string URL = "https://petstore.swagger.io/v2/pet/findByStatus?status=";
        private const string API_KEY = "special-key";
        public async Task<List<Pet>> FindByStatus(string petStatus)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = ConfigurationManager.AppSettings["FindByStatusUrl"];
                client.DefaultRequestHeaders.Add("api_key", API_KEY);
                var result =  await client.GetAsync($"{url}{petStatus}");
                string jsonString =  await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Pet>>(jsonString);
            }
        }
    }
}
