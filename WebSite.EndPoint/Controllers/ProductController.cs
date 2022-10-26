using Application.Services.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Services.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Services.Comment.Commands;
using Application.Services.Comment.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Models.ViewModels.Product;

namespace WebSite.EndPoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPDPService;
        private readonly IMediator mediator;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService
            , IGetCatalogItemPDPService getCatalogItemPDPService
            ,IMediator mediator)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
            this.getCatalogItemPDPService = getCatalogItemPDPService;
            this.mediator = mediator;
        }
        public IActionResult Index(CatalogPLPRequestDto catalogPLPRequest)
        {
            var data= getCatalogItemPLPService.Execute(catalogPLPRequest);
            return View(data);
        }

        public IActionResult Detail(int id)
        {
            ProductViewModel data = new ProductViewModel();
            data.catalogItemPDPDto= getCatalogItemPDPService.Execute(id);
            GetCommentOfCatalogItemRequest itemDto = new GetCommentOfCatalogItemRequest()
            {
                CatalogItemId= data.catalogItemPDPDto.Id
            };
            data.commentDtos = mediator.Send(itemDto).Result;
            
            return View(data);
        }

        public IActionResult SendComment(CommentDto commentDto)
        {
            SendCommentCommand sendComment = new SendCommentCommand(commentDto);
            var result= mediator.Send(sendComment).Result;
            return Json(result);
        }
    }
}
