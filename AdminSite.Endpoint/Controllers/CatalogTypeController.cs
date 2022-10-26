using AdminSite.Endpoint.Models.ViewModels;
using Application.Dtos;
using Application.Services.Catalogs.CatalogTypes.CRUDService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Controllers
{
    public class CatalogTypeController : Controller
    {
        private readonly ICatalogTypeService catalogTypeService;
        private readonly IMapper mapper;

        public CatalogTypeController(ICatalogTypeService catalogTypeService, IMapper mapper)
        {
            this.catalogTypeService = catalogTypeService;
            this.mapper = mapper;
        }
        public IActionResult Index(int? parentId, int page = 1, int pageSize = 100 ,string parentType="")
        {
            var CatalogType = catalogTypeService.GetList(parentId, page, pageSize);
            TempData["parentType"] = parentType;
            return View(CatalogType);
        }
        
        CatalogTypeViewModel CatalogType = new CatalogTypeViewModel();

        public IActionResult Create(int? parentId,string parentType)
        {
            CatalogType.ParentCatalogTypeId = parentId;
            CatalogType.ParentType = parentType;
            return View(CatalogType);
        }

        [HttpPost]
        public IActionResult Create(CatalogTypeViewModel CatalogType)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Add(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", new { parentid = CatalogType.ParentCatalogTypeId });
            }
            List<string> Message = result.Message;
            return View(Message);
        }


        public IActionResult Edit(int Id)
        {
            var model = catalogTypeService.FindById(Id);
            if (model.IsSuccess)
                CatalogType = mapper.Map<CatalogTypeViewModel>(model.Data);
            return View(CatalogType);
        }
        [HttpPost]
        public IActionResult Edit()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var model = mapper.Map<CatalogTypeDto>(CatalogType);
            var result = catalogTypeService.Edit(model);
            CatalogType.Message = result.Message;
            CatalogType = mapper.Map<CatalogTypeViewModel>(result.Data);
            return View();
        }

        public IActionResult Delete(int Id)
        {         
            var result= Json(catalogTypeService.Remove(Id));
            return result;
        }
    }
}
