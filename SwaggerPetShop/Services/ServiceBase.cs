using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services
{
    public class ServiceBase
    {
        public string apiKey = ConfigurationManager.AppSettings["ApiKey"];
    }
}
