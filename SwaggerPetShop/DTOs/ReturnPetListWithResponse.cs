using SwaggerPetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.DTOs
{
    public class ReturnPetListWithResponse
    {
        public List<Pet> PetList { get; set; }
        public string Message { get; set; }
    }
}
