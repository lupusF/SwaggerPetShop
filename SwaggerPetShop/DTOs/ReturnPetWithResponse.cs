using SwaggerPetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.DTOs
{
    public class ReturnPetWithResponse
    {
        public Pet Pet { get; set; }
        public string Message { get; set; }
    }
}
