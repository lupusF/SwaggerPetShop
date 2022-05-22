using SwaggerPetShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Implementation
{
    public class DeletePetService : IDeletePetService
    {
        private const string URL = "https://petstore.swagger.io/v2/pet/";
        private const string API_KEY = "special-key";
        public async Task<bool> DeletePet(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api-key", "special-key");
                HttpResponseMessage response = client.DeleteAsync($"{URL}{id}").Result;
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
