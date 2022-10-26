using Application.Services.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Services.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Services.Comment.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetCatalogItemPLPService getCatalogItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPDPService;
        private readonly IMediator mediator;

        public ProductController(IGetCatalogItemPLPService getCatalogItemPLPService
            , IGetCatalogItemPDPService getCatalogItemPDPService
            , IMediator mediator)
        {
            this.getCatalogItemPLPService = getCatalogItemPLPService;
            this.getCatalogItemPDPService = getCatalogItemPDPService;
            this.mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] CatalogPLPRequestDto request)
        {
            return Ok(getCatalogItemPLPService.Execute(request));
        }
        [HttpGet]
        [Route("PDP")]
        public IActionResult Get([FromQuery] int id)
        {
            return Ok(getCatalogItemPDPService.Execute(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto commentDto)
        {
            SendCommentCommand sendComment = new SendCommentCommand(commentDto);
            var result = mediator.Send(sendComment).Result;
            return Ok(result);
        }
    }
}
