using Newtonsoft.Json;
//using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Implementation
{
    public class FindByStatusService : IFindByStatusService
    {
        private const string URL = "https://petstore.swagger.io/v2/pet/findByStatus?status=";
        private const string API_KEY = "special-key";
        public async   Task<List<Pet>> FindByStatus(string petStatus)
        {
           // List<Pet> response;
            petStatus = "sold";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api_key", API_KEY);
                var result =  await client.GetAsync($"{URL}{petStatus}");
                string jsonString =  await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Pet>>(jsonString);
            }

          //  return null;
        }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    [JsonObject(Title ="Root") ] 
    public class Pet
    {
        public long id { get; set; }
        public Category category { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }
        public string name { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
