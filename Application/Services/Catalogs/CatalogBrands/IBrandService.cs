using Application.Dtos;
using Application.Interfaces.Context;
using Common;
using Domain.Catalogs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs.CatalogBrands
{
    public interface IBrandService
    {
        BaseDto Add(BrandDto brandDto);
        BaseDto Remove(int Id);
        BaseDto FindById(int Id);
        PaginatedItemsDto<BrandListDto> GetList(int page, int pageSize);
        SelectListDto GetCatalogType();
        List<GetBrandDto> GetBrands(string searchKey);
        SelectListDto AjaxMethod(string type, int value);
    }
    public class BrandService : IBrandService
    {
        private readonly IDataBaseContext context;

        public BrandService(IDataBaseContext context)
        {
            this.context = context;
        }

        public BaseDto Add(BrandDto brandDto)
        {

            if (brandDto.BrandId == 0)
            {
                var catalogType = context.CatalogTypes.Where(p => p.Id == brandDto.TypeId).SingleOrDefault();
                catalogType.CatalogBrands = new List<CatalogBrand> { new CatalogBrand { Brand = brandDto.Brand } };
                context.SaveChanges();
                return new BaseDto(IsSuccess: true,
                    Message: "برند با موفقیت ثبت شد");
            }
            else
            {
                var catalogType = context.CatalogTypes.Where(p => p.Id == brandDto.TypeId).Include(p => p.CatalogBrands).SingleOrDefault();
                var brand = context.CatalogBrands.Where(p => p.Id == brandDto.BrandId).Include(p=>p.CatalogTypes).SingleOrDefault();
                
                catalogType.CatalogBrands.Add(brand);
                context.SaveChanges();
                return new BaseDto(IsSuccess: true,
                    Message: "برند برای کاتالوگ ثبت شد");
            }

        }

        

        public BaseDto FindById(int Id)
        {
            var brand = context.CatalogBrands.Find(Id);
            return new BaseDto(IsSuccess: true, null);
        }

        public PaginatedItemsDto<BrandListDto> GetList(int page, int pageSize)
        {
            int totalCount = 0;
            var catalogTypeList = context.CatalogTypes.AsQueryable();
            var result = context.CatalogBrands
                .Include(p => p.CatalogTypes)
                .PagedResult(page, pageSize, out totalCount)
                .ToList()
                .Select(p => new BrandListDto
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    catalogType = p.CatalogTypes.ToList(),
                }).ToList();

            return new PaginatedItemsDto<BrandListDto>(page, pageSize, totalCount, result);
        }

        public BaseDto Remove(int Id)
        {
            var brand = context.CatalogBrands.Where(p => p.Id == Id).SingleOrDefault();
            if (brand == null)
            {
                return new BaseDto(IsSuccess: false, Message: "برند یافت نشد");
            }
            context.CatalogBrands.Remove(brand);
            context.SaveChanges();
            return new BaseDto(IsSuccess: true, Message: "برند با موفقیت حذف شد");
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


                    break;

                default:
                    break;
            }

            return model;
        }


        public List<GetBrandDto> GetBrands(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var brands = context.CatalogBrands
                    .Where(p => p.Brand.Contains(searchKey)).ToList();
                var data = brands.Select(p => new GetBrandDto
                {
                    Id = p.Id,
                    Name = $"{ p?.Brand ?? ""}"
                }).ToList();
                return data;
            }
            else
            {
                var brands = context.CatalogBrands
                    .OrderByDescending(p => p.Id)
                    .Take(10).ToList();
                var data = brands.Select(p => new GetBrandDto
                {
                    Id = p.Id,
                    Name = $"{ p?.Brand ?? ""}"
                }).ToList();
                return data;

            }
        }
        public SelectListDto GetCatalogType()
        {
            SelectListDto model = new SelectListDto();
            var parentcatalogtypes = context.CatalogTypes
                       .Include(p => p.ParentCatalogType)
                       .Include(p => p.ParentCatalogType)
                       .Include(p => p.ParentCatalogType.ParentCatalogType)
                       .ThenInclude(p => p.SubType)
                       .Where(p => p.ParentCatalogTypeId == null)
                       .Where(p => p.SubType.Count != 0)
                       .Select(p => new { p.Id, p.Type }).ToList();
            model.parentcatalogtypes = parentcatalogtypes.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{ p?.Type ?? ""}"
            }).ToList();

            return model;

        }

    }
    public class GetBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BrandListDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public List<CatalogType> catalogType { get; set; }
    }
    public class CatalogTypes
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    public class BrandDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int TypeId { get; set; }
    }



    public class SelectListDto
    {
        public SelectListDto()
        {
            this.parentcatalogtypes = new List<SelectListItem>();
            this.subtypes1 = new List<SelectListItem>();
            this.subtypes2 = new List<SelectListItem>();
        }

        public List<SelectListItem> parentcatalogtypes { get; set; }
        public List<SelectListItem> subtypes1 { get; set; }
        public List<SelectListItem> subtypes2 { get; set; }

        public int parentcatalogtypeid { get; set; }
        public int subtypeid1 { get; set; }
        public int subtypeid2 { get; set; }

    }
}
