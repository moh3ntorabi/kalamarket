using Application.Services.Discounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscountBasketService discountService;

        public DiscountApiController(IDiscountBasketService discountService)
        {
            this.discountService = discountService;
        }
        [HttpGet]
        [Route("SearchCatalogItem")]
        public async Task<IActionResult> SearchCatalogItem(string term)
        {
            return Ok(discountService.GetCatalogItems(term));
        }
    }
}
