using Application.Services.Catalogs.CatalogBrands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Controllers
{
    public class CatalogBrandController : Controller
    {
        private readonly IBrandService brandService;

        public CatalogBrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        public IActionResult Index()
        {
            var brandList= brandService.GetList(page:1,pageSize:30);
            return View(brandList);
        }
        
        public IActionResult Create(string searchKey)
        {
            var catalogTypes =brandService.GetCatalogType();
            return View(catalogTypes);
        }
        [HttpPost]
        public IActionResult Create(BrandDto brandDto)
        {
            return Json(brandService.Add(brandDto));
        }
        
        public IActionResult Delete(int Id)
        {
            return Json(brandService.Remove(Id));
        }
        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {

            var model = brandService.AjaxMethod(type, value);
            return Json(model);
        }
    }
}
