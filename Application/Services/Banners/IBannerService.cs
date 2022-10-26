using Application.Dtos;
using Application.Interfaces.Context;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using AutoMapper;
using Common;
using Domain.Banners;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Banners
{
    public interface IBannerService
    {
        void AddBanner(AddBannerDto bannerDto);
        PaginatedItemsDto<BannerDto> GetBanners(int page, int pageSize);
        BaseDto<AddBannerDto> Edit(AddBannerDto bannerDto);
        AddBannerDto FindById(int Id);
        BaseDto Remove(int id);
    }

    public class BannerService : IBannerService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public BannerService(IDataBaseContext context
            , IMapper mapper
            , IUriComposerService uriComposerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
        }


        public void AddBanner(AddBannerDto bannerDto)
        {
            var newBanner = mapper.Map<Banner>(bannerDto);
            context.Banners.Add(newBanner);
            context.SaveChanges();
        }

        public PaginatedItemsDto<BannerDto> GetBanners(int page, int pageSize)
        {
            int totalCount = 0;
            var banners = context.Banners
                .PagedResult(page, pageSize, out totalCount)
                .Select(p => new BannerDto
                {
                    Id = p.Id,
                    Image = uriComposerService.ComposeImageUri(p.Image),
                    Name = p.Name,
                    Link = p.Link,
                    IsActive = p.IsActive,
                    Position = p.Position,
                    Priority = p.Priority
                }).ToList();

            return new PaginatedItemsDto<BannerDto>(page, pageSize, totalCount, banners);
        }

        public BaseDto<AddBannerDto> Edit(AddBannerDto bannerDto)
        {
            var banner = context.Banners.SingleOrDefault(p => p.Id == bannerDto.Id);
            if (bannerDto.BannerImage != null)
            {

                mapper.Map(bannerDto, banner);
                context.SaveChanges();
                return new BaseDto<AddBannerDto>
                (
                    true,
                    new List<string> { $"بنر  با موفقیت ویرایش شد" },
                    mapper.Map<AddBannerDto>(banner)
                );
            }
            else
            {
                banner.Name = bannerDto.Name;
                banner.Link = bannerDto.Link;
                banner.Position = bannerDto.Position;
                banner.Priority = bannerDto.Priority;
                banner.IsActive = bannerDto.IsActive;
                context.SaveChanges();
                return new BaseDto<AddBannerDto>
                (
                    true,
                    new List<string> { $"بنر  با موفقیت ویرایش شد" },
                    mapper.Map<AddBannerDto>(banner)
                );
            }

        }

        public BaseDto Remove(int id)
        {
            var banner = context.Banners.Where(p => p.Id == id).SingleOrDefault();
            if (banner == null)
            {
                return new BaseDto
                (
                   IsSuccess: false,
                    Message: $"بنر یافت نشد"
                );
            }
            
            context.Banners.Remove(banner);
            context.SaveChanges();
            return new BaseDto
            (
                   IsSuccess: true,
                   Message: $"بنر حذف شد"
            );
        }

        public AddBannerDto FindById(int Id)
        {
            var banner = context.Banners.Find(Id);
            return (new AddBannerDto
            {
                Id = banner.Id,
                Name = banner.Name,
                Link = banner.Link,
                IsActive = banner.IsActive,
                Priority = banner.Priority,
                Position = banner.Position,
                Image = uriComposerService.ComposeImageUri(banner.Image),
            });
        }
    }

    public class BannerDto
    {
        public int Id { get; set; }
        [Display(Name = "نام بنر")]
        public string Name { get; set; }
        [Display(Name = "تصویر بنر")]
        public string Image { get; set; }
        [Display(Name = "لینک")]
        public string Link { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
        [Display(Name = "موقعیت نمایش")]
        public Position Position { get; set; }
        [Display(Name = "ترتیب نمایش")]
        public int Priority { get; set; }
    }
    public class AddBannerDto
    {
        public int Id { get; set; }
        [Display(Name = "نام بنر")]
        public string Name { get; set; }
        [Display(Name = "تصویر بنر")]
        public string Image { get; set; }
        [Display(Name = "لینک")]
        public string Link { get; set; }
        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }
        [Display(Name = "موقعیت نمایش")]
        public Position Position { get; set; }
        [Display(Name = "ترتیب نمایش")]
        public int Priority { get; set; }
        public IFormFile BannerImage { get; set; }
    }
}
