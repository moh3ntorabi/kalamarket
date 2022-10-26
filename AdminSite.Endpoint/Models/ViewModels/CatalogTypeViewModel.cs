using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Models.ViewModels
{
    public class CatalogTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required]
        [MaxLength(100, ErrorMessage = "نام دسته بندی باید حداکثر ۱۰۰ کاراکتر باشد")]
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
        public string ParentType { get; set; }
        public List<string> Message = new List<string>();

    }
}
