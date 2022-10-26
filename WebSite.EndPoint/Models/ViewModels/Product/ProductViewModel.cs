using Application.Services.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Services.Comment.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        public CatalogItemPDPDto catalogItemPDPDto { get; set; }
        public List<GetCommentDto> commentDtos { get; set; }
    }
}
