using AutoMapper;
using MenuRestAPI_Marcoratti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        // Constructor
        public MappingProfile() {

            CreateMap<Product, ProductReturnDTO>().ReverseMap(); // Criando um Map do Model para o DTO e vice-versa
            CreateMap<Category, CategoryReturnDTO>().ReverseMap();
        }

    }
}
