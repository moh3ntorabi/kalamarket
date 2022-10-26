using Application.Services.Catalogs.CatalogBrands;
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
    public class BrandApiController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandApiController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpGet]
        [Route("SearchBrands")]
        public async Task<IActionResult> SearchBrands(string term)
        {
            return Ok(brandService.GetBrands(term));
        }
    }
}
