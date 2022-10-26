using Application.Interfaces.Context;
using Application.Services.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using Domain.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HomePages
{
    public interface IHomePageService
    {
        HomePageDto GetData();
    }

    public class HomePageService : IHomePageService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposerService;
        private readonly IGetCatalogItemPLPService getCatalogItemPLP;

        public HomePageService(IDataBaseContext context, IUriComposerService uriComposerService
            , IGetCatalogItemPLPService getCatalogItemPLP)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
            this.getCatalogItemPLP = getCatalogItemPLP;
        }
        public HomePageDto GetData()
        {
            var banners = context.Banners.Where(p => p.IsActive == true)
                .OrderBy(p => p.Priority)
                .ThenByDescending(p => p.Id)
                .Select(p => new BannerDto
                {
                    Id = p.Id,
                    Image = uriComposerService.ComposeImageUri(p.Image),
                    Link = p.Link,
                    Position = p.Position,
                }).ToList();

            var mostPopular = getCatalogItemPLP.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                page = 1,
                pageSize = 20,
                SortType = SortType.MostPopular,
            }).Data.ToList();
            var bestSellers = getCatalogItemPLP.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                page = 1,
                pageSize = 20,
                SortType = SortType.Bestselling,
            }).Data.ToList();

            return new HomePageDto
            {
                Banners = banners,
                MostPopular=mostPopular,
                BestSellers=bestSellers,
            };
        }
    }

    public class HomePageDto
    {
        public List<BannerDto> Banners { get; set; }
        public List<CatalogPLPDto> MostPopular { get; set; }
        public List<CatalogPLPDto> BestSellers { get; set; }
    }

    public class BannerDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public Position Position { get; set; }
    }
}
