using Application.Dtos;
using Application.Interfaces.Context;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using AutoMapper;
using Common;
using Domain.Catalogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs.CatalogItems.CatalogItemServices
{
    public interface ICatalogItemService
    {
        SelectListDto GetCatalogType();
        PaginatedItemsDto<CatalogItemListDto> GetCatalogList(int page, int pageSize);
        public List<CatalogBrandDto> GetBrandFilter(int catalogTypeId);
        SelectListDto AjaxMethod(string type, int value);


        void AddToMyFavourite(string UserId, int CatalogItemId);
        PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string userId, int page = 1, int pageSize = 20);

        BaseDto RemoveItem(int Id);
    }
    public class CatalogItemService : ICatalogItemService
    {

        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public CatalogItemService(IDataBaseContext context, IMapper mapper
            , IUriComposerService uriComposerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
        }

        public void AddToMyFavourite(string UserId, int CatalogItemId)
        {
            var catalogItem = context.CatalogItems.Find(CatalogItemId);
            CatalogItemFavourite catalogItemFavourite = new CatalogItemFavourite
            {
                CatalogItem = catalogItem,
                UserId = UserId,
            };
            context.CatalogItemFavourites.Add(catalogItemFavourite);
            context.SaveChanges();
        }


        public List<CatalogBrandDto> GetBrandFilter(int catalogTypeId)
        {
            List<CatalogBrand> brands = new List<CatalogBrand>();
            var catalogtype = context.CatalogTypes
                   .Include(p => p.ParentCatalogType)
                   .Include(p => p.ParentCatalogType)
                   .Include(p => p.ParentCatalogType.ParentCatalogType)
                   .ThenInclude(p => p.SubType)
                   .Where(p => p.ParentCatalogTypeId == catalogTypeId).ToList();
            if (catalogtype != null)
            {
                foreach (var item in catalogtype)
                {
                    brands.AddRange(context.CatalogBrands
                        .Include(p => p.CatalogTypes)
                        .Where(p => p.Id == item.Id).ToList());
                }
            }
            brands = context.CatalogBrands
                 .Include(p => p.CatalogTypes)
                 .Where(p => p.Id == catalogTypeId).ToList();

            var data = mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public PaginatedItemsDto<CatalogItemListDto> GetCatalogList(int page, int pageSize)
        {
            int rowCount = 0;
            var data = context.CatalogItems
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .ToPaged(page, pageSize, out rowCount)
                .OrderByDescending(p => p.Id)
                .Select(p => new CatalogItemListDto
                {
                    Id = p.Id,
                    Brand = p.CatalogBrand.Brand,
                    Type = p.CatalogType.Type,
                    AvailableStock = p.AvailableStock,
                    MaxStockThreshold = p.MaxStockThreshold,
                    RestockThreshold = p.RestockThreshold,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new PaginatedItemsDto<CatalogItemListDto>(page, page, rowCount, data);

        }
        public SelectListDto AjaxMethod(string type, int value)
        {
            SelectListDto model = new SelectListDto();
            switch (type)
            {
                case "parentcatalogtypes":
                    model.subtypes1 = context.CatalogTypes
                   .Include(p => p.ParentCatalogType)
                   .Include(p => p.ParentCatalogType)
                   .Include(p => p.ParentCatalogType.ParentCatalogType)
                   .ThenInclude(p => p.SubType)
                   .Where(p => p.ParentCatalogTypeId == value)
                   .Select(p => new { p.Id, p.Type }).ToList()
                                      .Select(p => new SelectListItem
                                      {
                                          Value = p.Id.ToString(),
                                          Text = $"{ p?.Type ?? ""}"
                                      }).ToList();

                    break;
                case "subtype1":
                    model.subtypes2 = context.CatalogTypes
                 .Include(p => p.ParentCatalogType)
                 .Include(p => p.ParentCatalogType)
                 .Include(p => p.ParentCatalogType.ParentCatalogType)
                 .ThenInclude(p => p.SubType)
                 .Where(p => p.ParentCatalogTypeId == value)
                 .Select(p => new { p.Id, p.Type }).ToList()
                                    .Select(p => new SelectListItem
                                    {
                                        Value = p.Id.ToString(),
                                        Text = $"{ p?.Type ?? ""}"
                                    }).ToList();

                    model.brands = context.CatalogBrands
                                    .Include(p => p.CatalogTypes)
                                    .Where(p => p.CatalogTypes.Any(c => c.Id == value))
                                    .Select(p => new { p.Id, p.Brand }).ToList()
                                    .Select(p => new SelectListItem
                                    {
                                        Value = p.Id.ToString(),
                                        Text = $"{ p?.Brand ?? ""}"
                                    }).ToList();
                    break;
                case "subtype2":
                    model.brands = context.CatalogBrands
                                    .Include(p => p.CatalogTypes)
                                    .Where(p => p.CatalogTypes.Any(c => c.Id == value))
                                    .Select(p => new { p.Id, p.Brand }).ToList()
                                    .Select(p => new SelectListItem
                                    {
                                        Value = p.Id.ToString(),
                                        Text = $"{ p?.Brand ?? ""}"
                                    }).ToList();
                    break;
                default:
                    break;
            }

            return model;
        }



        public SelectListDto GetCatalogType()
        {
            SelectListDto model = new SelectListDto();

            model.parentcatalogtypes = context.CatalogTypes
                        .Include(p => p.ParentCatalogType)
                        .Include(p => p.ParentCatalogType)
                        .Include(p => p.ParentCatalogType.ParentCatalogType)
                        .ThenInclude(p => p.SubType)
                        .Where(p => p.ParentCatalogTypeId == null)
                        .Where(p => p.SubType.Count != 0)
                        .Select(p => new { p.Id, p.Type }).ToList()
                                           .Select(p => new SelectListItem
                                           {
                                               Value = p.Id.ToString(),
                                               Text = $"{ p?.Type ?? ""}"
                                           }).ToList();
            return model;
        }

        public PaginatedItemsDto<FavouriteCatalogItemDto> GetMyFavourite(string userId, int page = 1, int pageSize = 20)
        {
            var model = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemFavourites)
                .Where(p => p.CatalogItemFavourites.Any(f => f.UserId == userId))
                .OrderByDescending(p => p.Id)
                .AsQueryable();
            int rowCount = 0;

            var data = model.PagedResult(page, pageSize, out rowCount)
                .Select(p => new FavouriteCatalogItemDto
                {
                    AvailableStock = p.AvailableStock,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                }).ToList();
            return new PaginatedItemsDto<FavouriteCatalogItemDto>(page, pageSize, rowCount, data);
        }

        public BaseDto RemoveItem(int Id)
        {
            var catalogItem = context.CatalogItems.Where(p => p.Id == Id).SingleOrDefault();
            if (catalogItem == null)
            {
                return new BaseDto
                (
                   IsSuccess: false,
                   Message: "محصول یافت نشد"
                    );
            }
            context.CatalogItems.Remove(catalogItem);
            context.SaveChanges();
            return new BaseDto(IsSuccess: true, Message: "محصول با موفقیت حذف شد");
        }
    }


    public class FavouriteCatalogItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public int AvailableStock { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class CatalogBrandDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
    }
    public class ListCatalogTypeDto
    {
        public int Id { get; set; }
        public string ParentType { get; set; }
    }

    public class CatalogItemListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
    }
    public class SelectListDto
    {
        public SelectListDto()
        {
            this.parentcatalogtypes = new List<SelectListItem>();
            this.brands = new List<SelectListItem>();
            this.subtypes1 = new List<SelectListItem>();
            this.subtypes2 = new List<SelectListItem>();
        }

        public List<SelectListItem> parentcatalogtypes { get; set; }
        public List<SelectListItem> brands { get; set; }
        public List<SelectListItem> subtypes1 { get; set; }
        public List<SelectListItem> subtypes2 { get; set; }

        public int parentcatalogtypeid { get; set; }
        public int brandid { get; set; }
        public int subtypeid1 { get; set; }
        public int subtypeid2 { get; set; }

    }

}
