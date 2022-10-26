using Application.Services.Catalogs.CatalogItems.CatalogItemServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewComponents
{
    public class BrandFilter:ViewComponent
    {
        private readonly ICatalogItemService catalogItemService;

        public BrandFilter(ICatalogItemService catalogItemService)
        {
            this.catalogItemService = catalogItemService;
        }


        public IViewComponentResult Invoke(string id)
        {
            int catalogTypeId = Convert.ToInt32(id);
            var brands = catalogItemService.GetBrandFilter(catalogTypeId);
            return View(viewName: "BrandFilter", model: brands);
        }
    }
}
