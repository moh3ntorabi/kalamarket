﻿using Application.Interfaces.Context;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Orders.CustomerOrderService
{
    public interface ICustomerOrderService
    {
        List<MyOrderDto> GetMyOrder(string uderId);
    }

    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly IDataBaseContext context;

        public CustomerOrderService(IDataBaseContext context)
        {
            this.context = context;
        }
        public List<MyOrderDto> GetMyOrder(string userId)
        {
            var orders = context.Orders
                .Include(p => p.OrderItems)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.OrderDate)
                .Select(p => new MyOrderDto
                {
                    Id=p.Id,
                    Date=context.Entry(p).Property("InsertTime").CurrentValue.ToString(),
                    OrderStatus=p.OrderStatus,
                    PaymentStatus=p.PaymentStatus,
                    Price=p.totalprice(),
                }).ToList();
            return orders;
        }
    }

    public class MyOrderDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
