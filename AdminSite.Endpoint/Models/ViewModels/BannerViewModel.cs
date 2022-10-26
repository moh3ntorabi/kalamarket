using Application.Services.Banners;
using Domain.Banners;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Models.ViewModels
{
    public class BannerViewModel
    {
        public BannerDto Banner { get; set; }
        public IFormFile BannerImage { get; set; }
    }
}
