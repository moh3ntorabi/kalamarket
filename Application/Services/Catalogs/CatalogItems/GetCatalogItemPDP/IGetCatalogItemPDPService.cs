using Application.Dtos;
using Application.Interfaces.Context;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs.CatalogItems.GetCatalogItemPDP
{
    public interface IGetCatalogItemPDPService
    {
        CatalogItemPDPDto Execute(int id);
    }
    public class GetCatalogItemPDPService : IGetCatalogItemPDPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposer;

        public GetCatalogItemPDPService(IDataBaseContext context, IUriComposerService uriComposer)
        {
            this.context = context;
            this.uriComposer = uriComposer;
        }
        public CatalogItemPDPDto Execute(int id)
        {
            var catalogItem = context.CatalogItems
                .Include(p => p.CatalogBrand)
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogItemImages)
                .Include(p => p.CatalogItemFeatures)
                .Include(p=>p.Discounts)
                .SingleOrDefault(p => p.Id == id);
            var features = catalogItem.CatalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value,
                }).ToList()
                .GroupBy(p => p.Group);
            var similarCatalogItems = context
              .CatalogItems
              .Include(p => p.CatalogItemImages)
              .Where(p => p.CatalogTypeId == catalogItem.CatalogTypeId)
              .Take(10)
              .Select(p => new SimilarCatalogItemDto
              {
                  Id = p.Id,
                  Images = uriComposer.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                  Price = p.Price,
                  Name = p.Name
              }).ToList();

            return new CatalogItemPDPDto
            {
                Features = features,
                SimilarCatalogs = similarCatalogItems,
                Id = catalogItem.Id,
                Name = catalogItem.Name,
                Brand = catalogItem.CatalogBrand.Brand,
                Type = catalogItem.CatalogType.Type,
                Price = catalogItem.Price,
                Description = catalogItem.Description,
                Images = catalogItem.CatalogItemImages.Select(p => uriComposer.ComposeImageUri(p.Src)).ToList(),
                OldPrice=catalogItem.OldPrice,
                PercentDiscount=catalogItem.PercentDiscount,
            };
        }
    }

    public class CatalogItemPDPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int? OldPrice { get; set; }
        public int? PercentDiscount { get; set; }
        public List<string> Images { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGrouping<string, PDPFeaturesDto>> Features { get; set; }
        public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }

    }

    public class PDPFeaturesDto
    {
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }


    public class SimilarCatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
    }
}
