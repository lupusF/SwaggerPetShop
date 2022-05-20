﻿using SwaggerPetShop.Model;
using SwaggerPetShop.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerPetShop.Services.Interface
{
    public interface IAddPetService
    {
        public Task<bool> AddPet(Pet item);
    }
}
