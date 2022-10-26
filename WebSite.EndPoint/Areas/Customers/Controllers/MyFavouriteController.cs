using Application.Services.Catalogs.CatalogItems.CatalogItemServices;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class MyFavouriteController : Controller
    {
        private readonly ICatalogItemService catalogItemService;
        private readonly UserManager<User> userManager;

        public MyFavouriteController(ICatalogItemService catalogItemService
            ,UserManager<User> userManager)
        {
            this.catalogItemService = catalogItemService;
            this.userManager = userManager;
        }
        public IActionResult Index(int page=1,int pageSize=20)
        {
            var user = userManager.GetUserAsync(User).Result;
            var data = catalogItemService.GetMyFavourite(user.Id, page,  pageSize);
            return View(data);
        }
        public IActionResult AddToMyFavourite(int catalogItemId)
        {
            var user = userManager.GetUserAsync(User).Result;
            catalogItemService.AddToMyFavourite(user.Id, catalogItemId);
            return RedirectToAction(nameof(Index));
        }
    }
}
