using Application.Dtos;
using Application.Interfaces.Context;
using Common;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Discounts
{
    public interface IDiscountHistoryService
    {
        void InsertDiscountUsageHistory(int DiscountId, int OrderId);
        DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId);
        PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId,
            string userId, int pageIndex, int pageSize);
    }
    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly IDataBaseContext context;

        public DiscountHistoryService(IDataBaseContext context)
        {
            this.context = context;
        }
        public PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string userId, int pageIndex, int pageSize)
        {
            var query = context.DiscountUsageHistories.AsQueryable();
            if (discountId.HasValue && discountId > 0)
                query= query.Where(p => p.DiscountId == discountId);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(p => p.Order != null && p.Order.UserId == userId);

            query = query.OrderByDescending(c => c.CreatedOn);
            var pageItems = query.PagedResult(pageIndex, pageSize, out int rowsCount);
            return new PaginatedItemsDto<DiscountUsageHistory>(pageIndex, pageSize,rowsCount, query.ToList());
                
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            if (discountUsageHistoryId == 0)
                return null;
            var discountUsages=context.DiscountUsageHistories.Find(discountUsageHistoryId);
            return discountUsages;
        }

        public void InsertDiscountUsageHistory(int DiscountId, int OrderId)
        {
            var order=context.Orders.Find(OrderId);
            var discount = context.Discounts.Find(DiscountId);
            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
            {
                CreatedOn = DateTime.Now,
                Discount = discount,
                Order=order,
            };
            context.DiscountUsageHistories.Add(discountUsageHistory);
            context.SaveChanges();
        }

    }
}
