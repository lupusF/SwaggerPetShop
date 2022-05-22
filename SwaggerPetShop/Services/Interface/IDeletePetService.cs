using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Interface
{
    public interface IDeletePetService
    {
        public Task<bool> DeletePet(long id);
    }
}
