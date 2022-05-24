using Newtonsoft.Json;
using SwaggerPetShop.DTOs;
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
    public class FindByStatusService : ServiceBase, IFindByStatusService
    {
        public async Task<ReturnPetListWithResponse> FindByStatus(string petStatus)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var url = ConfigurationManager.AppSettings["FindByStatusUrl"];
                    client.DefaultRequestHeaders.Add("api_key", apiKey);
                    var result = await client.GetAsync($"{url}{petStatus}");
                    string jsonString = await result.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<List<Pet>>(jsonString);

                    if (result.IsSuccessStatusCode)
                    {
                        return new ReturnPetListWithResponse
                        {
                            PetList = response,
                            Message = result.ReasonPhrase
                        };
                    }
                    else
                    {
                        return new ReturnPetListWithResponse
                        {
                            Message = result.ReasonPhrase
                        };
                    }
                }
                catch (Exception exception)
                {
                    return new ReturnPetListWithResponse
                    {
                        Message = exception.Message
                    };
                }
            }
        }
    }
}
