using SwaggerPetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Interface
{
    public interface IGetByIdService
    {
        public Task<Pet> GetById(string id);
    }
}
