using AutoMapper;
using LivrariaHBSIS.Application.WebApi.AppModels;
using LivrariaHBSIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaHBSIS.Application.WebApi.MapperProfiles
{
    public class AppModelToEntityProfile : Profile
    {
        public AppModelToEntityProfile()
        {
            CreateMap<LivroAppModel, Livro>();
            CreateMap<CategoriaAppModel, Categoria>();
        }
    }
}
