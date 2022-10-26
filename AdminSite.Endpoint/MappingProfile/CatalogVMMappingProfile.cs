using AdminSite.Endpoint.Models.ViewModels;
using Application.Services.Catalogs.CatalogTypes.CRUDService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.MappingProfile
{
    public class CatalogVMMappingProfile : Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
        }
    }
}
