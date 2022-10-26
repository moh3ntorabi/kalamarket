using Application.Services.Banners;
using AutoMapper;
using Domain.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfile
{
    public class BannerMappingProfile:Profile
    {
        public BannerMappingProfile()
        {
            CreateMap<AddBannerDto, Banner>().ReverseMap();
        }
    }
}
