using AdminSite.Endpoint.Binders;
using Application.Services.Discounts.CRUDServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Controllers
{
    public class DiscountController : Controller
    {
        
        private readonly IDiscountService discountService;

        public DiscountController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        
        public IActionResult Index()
        {
            return View(discountService.GetList(page: 1, pageSize: 30));
        }
        public IActionResult Delete(int Id)
        {
            return Json(discountService.RemoveDiscount(Id));
        }
        
        public IActionResult AddDiscount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDiscount([ModelBinder(BinderType = typeof(DiscountEntityBinder))] AddDiscountDto model)
        {
            discountService.AddNewDiscount(model);
            return View();
        }
    }
}
