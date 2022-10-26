using AdminSite.Endpoint.Models;
using Application.Dtos;
using Application.Services.Catalogs.CatalogItems.AddNewCatalogItem;
using Application.Services.Catalogs.CatalogItems.CatalogItemServices;
using Infrastructure.ExternalApi.ImageServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdminSite.Endpoint.Controllers
{
    public class CatalogItemController : Controller
    {
        private readonly ILogger<CatalogItemController> _logger;




        private readonly ICatalogItemService catalogItemService;
        private readonly IImageUploadService imageUploadService;
        private readonly IAddNewCatalogItemService addNewCatalogItemService;

        public CatalogItemController(ILogger<CatalogItemController> logger
            , ICatalogItemService catalogItemService
            , IImageUploadService imageUploadService
            , IAddNewCatalogItemService addNewCatalogItemService)
        {
            _logger = logger;
            this.catalogItemService = catalogItemService;
            this.imageUploadService = imageUploadService;
            this.addNewCatalogItemService = addNewCatalogItemService;
        }

        public IActionResult Index(int page= 1, int pageSize = 100)
        {
            var catalogItems = catalogItemService.GetCatalogList(page, pageSize);
            return View(catalogItems);
        }
        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {

            var model = catalogItemService.AjaxMethod(type, value);
            return Json(model);
        }
        public IActionResult Create()
        {
            var ParentCatalogType = catalogItemService.GetCatalogType();
            return View(ParentCatalogType);
        }


        [HttpPost]
        public IActionResult AddNewCatalogItem(AddNewCatalogItemDto Data)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new JsonResult(new BaseDto<int>(false, allErrors.Select(p => p.ErrorMessage).ToList(), 0));
            }
            List<IFormFile> Files = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                Files.Add(file);
            }
            List<AddNewCatalogItemImage_Dto> images = new List<AddNewCatalogItemImage_Dto>();
            if (Files.Count > 0)
            {
                //Upload 
                var result = imageUploadService.Upload(Files);
                foreach (var item in result)
                {
                    images.Add(new AddNewCatalogItemImage_Dto { Src = item });
                }
            }
            Data.Images = images;
            var resultService = addNewCatalogItemService.Execute(Data);
            return new JsonResult(resultService);
        }

        public IActionResult Delete(int Id)
        {
            return Json(catalogItemService.RemoveItem(Id));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
