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
    public class UpdatePetService : ServiceBase, IUpdatePetService
    {
        public async Task<ReturnPetWithResponse> UpdatePet(Pet item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var url = ConfigurationManager.AppSettings["UpdatePetUrl"];
                    client.DefaultRequestHeaders.Add("api_key", apiKey);

                    var jsonBody = JsonConvert.SerializeObject(item);
                    HttpContent cont = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PutAsync(url, cont).Result;
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

