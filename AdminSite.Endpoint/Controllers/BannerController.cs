using AdminSite.Endpoint.Models.ViewModels;
using Application.Services.Banners;
using AutoMapper;
using Infrastructure.CacheHelpers;
using Infrastructure.ExternalApi.ImageServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Controllers
{
    public class BannerController : Controller
    {

        private readonly IBannerService banners;
        private readonly IImageUploadService imageUploadService;
        private readonly IDistributedCache _cache;
        private readonly IMapper mapper;

        public BannerController(IBannerService banners,
            IImageUploadService imageUploadService
            , IDistributedCache distributedCache
            , IMapper mapper)
        {
            this.banners = banners;
            this.imageUploadService = imageUploadService;
            _cache = distributedCache;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var banner = banners.GetBanners(page: 1, pageSize: 20);
            return View(banner);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddBannerDto bannerDto)
        {
            //Upload 
            var result = imageUploadService.Upload(new List<IFormFile> { bannerDto.BannerImage });
            if (result.Count > 0)
            {
                bannerDto.Image = result.FirstOrDefault();
                banners.AddBanner(bannerDto);

                _cache.Remove(CacheHelper.GenerateHomePageCacheKey());
            }
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int Id)
        {
            var bannerDto = banners.FindById(Id);
                
            return View(bannerDto);
        }
        [HttpPost]
        public IActionResult Edit(AddBannerDto bannerDto)
        {
            if (bannerDto.BannerImage != null)
            {
                var result = imageUploadService.Upload(new List<IFormFile> { bannerDto.BannerImage });

                if (result.Count > 0)
                {
                    bannerDto.Image = result.FirstOrDefault();
                    banners.Edit(bannerDto);

                    _cache.Remove(CacheHelper.GenerateHomePageCacheKey());
                }
            }
            else
            {
                banners.Edit(bannerDto);

                _cache.Remove(CacheHelper.GenerateHomePageCacheKey());
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            return Json(banners.Remove(Id));
        }
    }
}
