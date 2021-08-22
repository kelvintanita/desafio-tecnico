using AutoMapper;
using DesafioTecnico.Application.ViewModels;
using DesafioTecnico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecnico.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Categoria, CategoriaCreateEditViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoCreateEditViewModel>().ReverseMap();

            CreateMap<Documento, DocumentoViewModel>()
                .ForMember(p => p.Categoria, opt => opt.MapFrom(src => src.Categoria.Nome))
                .ForMember(p => p.Departamento , opt => opt.MapFrom(src => src.Departamento.Nome)).ReverseMap();

            CreateMap<Documento, DocumentoCreateViewModel>().ReverseMap();
            CreateMap<Documento, DocumentoEditViewModel>().ReverseMap();
        }
    }
}
