using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesTest.Builders
{
    public class OrderBuilder
    {
        public Order _order;
        public string TestBuyerId => "68742";
        public int TestCatalogItemId => 234;
        public string TestProductName => "Test Name";
        public string TestPictureUri => "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png";
        public int TestUnitPrice = 1000;
        public int TestUnits = 2;


        public Order CreateOrderWithDefaultValue()
        {
            List<OrderItem> testOrderItem = new List<OrderItem>()
            {
                new OrderItem(TestCatalogItemId, TestProductName
                , TestPictureUri, TestUnitPrice, TestUnits)
            };
            return new Order(TestBuyerId, new AddressBuilder().Build(), testOrderItem, PaymentMethod.OnlinePayment, null);
        }
    }
}
