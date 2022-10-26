using Domain.Orders;
using EntitiesTest.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EntitiesTest.OrderTest
{
    public class OrderStatusTest
    {
        [Fact]
        public void When_order_is_delivered_OrderStatus_change_to_Delivered()
        {
            var builder = new OrderBuilder();
            var order = builder.CreateOrderWithDefaultValue();
            order.OrderDelivered();

            Assert.Equal(OrderStatus.Delivered, order.OrderStatus);
        }
    }
}
