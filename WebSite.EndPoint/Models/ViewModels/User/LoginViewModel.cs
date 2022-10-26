using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="لطفا ایمیل خود را وارد نمایید")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا پسورد خود را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }
        [Display(Name ="RememberMe")]
        public bool IsPersistance { get; set; }

        public string ReturnUrl { get; set; }
    }
}
