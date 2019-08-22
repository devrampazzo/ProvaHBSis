using AutoMapper;
using LivrariaHBSIS.Application.WebApi.AppModels;
using LivrariaHBSIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaHBSIS.Application.WebApi.MapperProfiles
{
    public class EntityToAppModelProfile : Profile
    {
        public EntityToAppModelProfile()
        {
            DateTimeFormatInfo formatInfo = CultureInfo.CurrentUICulture.DateTimeFormat;
            CreateMap<Livro, LivroAppModel>()
                .ForMember(x => x.DescricaoCategoria, opt => opt.MapFrom(y => y.Categoria.Descricao))
                .ForMember(x => x.DataCadastro, opt => opt.MapFrom(y => y.DataCadastro.ToString(formatInfo)));

            CreateMap<Categoria, CategoriaAppModel>();
        }
    }
}
