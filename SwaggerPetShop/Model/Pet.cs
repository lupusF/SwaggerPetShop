using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Model
{
    [JsonObject(Title = "Root")]
    public class Pet
    {
        public long id { get; set; }
        public Category category { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }
        public string name { get; set; }
    }
}
