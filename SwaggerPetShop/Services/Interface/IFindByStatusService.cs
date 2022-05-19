//using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Interface
{
    public interface IFindByStatusService
    {
        public Task<List<Pet>> FindByStatus(string petStatus);

    }
}
