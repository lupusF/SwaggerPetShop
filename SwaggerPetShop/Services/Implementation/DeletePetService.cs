using SwaggerPetShop.DTOs;
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
    public class DeletePetService : ServiceBase, IDeletePetService
    {
        public async Task<ReturnPetWithResponse> DeletePet(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var url = ConfigurationManager.AppSettings["DeletePetUrl"];
                    client.DefaultRequestHeaders.Add("api-key", apiKey);
                    HttpResponseMessage response = client.DeleteAsync($"{url}{id}").Result;

                    return new ReturnPetWithResponse
                    {
                        Message = response.ReasonPhrase
                    };
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
