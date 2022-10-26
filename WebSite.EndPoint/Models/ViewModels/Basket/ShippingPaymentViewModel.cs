using Application.Services.Baskets;
using Application.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.EndPoint.Models.ViewModels.Basket
{
    public class ShippingPaymentViewModel
    {
        public BasketDto Basket{ get; set; }
        public List<UserAddressDto> UserAddresses{ get; set; }
    }
}
