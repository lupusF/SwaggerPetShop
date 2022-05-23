using SwaggerPetShop.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Interface
{
    public interface IDeletePetService
    {
        public Task<ReturnPetWithResponse> DeletePet(long id);
    }
}
