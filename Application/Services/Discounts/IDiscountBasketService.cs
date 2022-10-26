using Application.Dtos;
using Application.Interfaces.Context;
using Domain.Discounts;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Discounts
{
    public interface IDiscountBasketService
    {
        List<CatalogItemDto> GetCatalogItems(string searchKey);
        bool ApplyDiscountInBasket(string CouponCode, int BasketId);
        bool RemoveDiscountFromBasket(int BasketId);
        BaseDto IsDiscountValid(string CouponCode, User user);
    }
    public class DiscountBasketService : IDiscountBasketService
    {
        private readonly IDataBaseContext context;
        private readonly IDiscountHistoryService discountHistoryService;

        public DiscountBasketService(IDataBaseContext context
            , IDiscountHistoryService discountHistoryService)
        {
            this.context = context;
            this.discountHistoryService = discountHistoryService;
        }
        public bool ApplyDiscountInBasket(string CouponCode, int BasketId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .Include(p => p.AppliedDiscount)
                .FirstOrDefault(p => p.Id == BasketId);

            var discount = context.Discounts.Where(p => p.CouponCode.Equals(CouponCode)).FirstOrDefault();
            basket.AppliedDiscountCode(discount);
            context.SaveChanges();
            return true;

        }

        public List<CatalogItemDto> GetCatalogItems(string searchKey)
        {
            if (!string.IsNullOrEmpty(searchKey))
            {
                var data = context.CatalogItems
                    .Where(p => p.Name.Contains(searchKey))
                    .Select(p => new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }).ToList();
                return data;
            }
            else
            {
                var data = context.CatalogItems
                    .OrderByDescending(p => p.Id)
                    .Take(10)
                    .Select(p => new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }).ToList();
                return data;
            }
        }

        public BaseDto IsDiscountValid(string CouponCode, User user)
        {
            var discount = context.Discounts.Where(p => p.CouponCode.Equals(CouponCode))
                .FirstOrDefault();
            if (discount == null)
            {
                return new BaseDto
                (
                    IsSuccess: false,
                    Message: "کد تخفیف معتبر نمی‌باشد"
               );
            }
            var now = DateTime.UtcNow;
            if (discount.StartDate.HasValue)
            {
                var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(now) > 0)
                    return new BaseDto
                    (
                        IsSuccess: false,
                        Message: "هنوز زمان استفاده از این کد تخفیف فرا نرسیده است"
                    );
            }
            if (discount.EndDate.HasValue)
            {
                var endDate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (endDate.CompareTo(now) < 0)
                    return new BaseDto
                    (
                        IsSuccess: false,
                        Message: "کد تخفیف منقضی شده است"
                    );
            }

            var checkLimit = CheckDiscountLimitations(discount, user);

            if (checkLimit.IsSuccess == false)
                return checkLimit;
            return new BaseDto
           (
                IsSuccess: false,
                Message: "کد تخفیف منقضی شده است"
           );
        }

        private BaseDto CheckDiscountLimitations(Discount discount, User user)
        {
            switch (discount.DiscountLimitation)
            {
                case DiscountLimitationType.Unlimited:
                    {
                        return new BaseDto
                        (
                            IsSuccess: true,
                            Message: "کد تخفیف منقضی شده است"
                        );
                    }
                case DiscountLimitationType.NTimesOnly:
                    {
                        var totalUsage = discountHistoryService.GetAllDiscountUsageHistory(discount.Id, null, 0, 1).Data.Count();
                        if (totalUsage < discount.LimitationTimes)
                        {
                            return new BaseDto
                            (
                                IsSuccess: true,
                                Message: "کد تخفیف منقضی شده است"
                            );
                        }
                        else
                        {
                            return new BaseDto
                            (
                                IsSuccess: false,
                                Message: "ظرفیت استفاده از این کد تخفیف تکمیل شده است"
                            );
                        }
                    }
                case DiscountLimitationType.NTimesPerCustomer:
                    {
                        if (user != null)
                        {
                            var totalUsage = discountHistoryService.GetAllDiscountUsageHistory(discount.Id, user.Id, 0, 1).Data.Count();
                            if (totalUsage < discount.LimitationTimes)
                            {
                                return new BaseDto
                                (
                                    IsSuccess: false,
                                    Message: "ظرفیت استفاده از این کد تخفیف تکمیل شده است"
                                );
                            }
                            else
                            {
                                return new BaseDto
                                (
                                    IsSuccess: false,
                                    Message: "تعدادی که شما مجاز به استفاده از این تخفیف بوده اید به پایان رسیده است"
                                );
                            }
                        }
                        else
                        {
                            return new BaseDto
                            (
                                IsSuccess: true,
                                Message: null
                            );
                        }
                    }
                default:
                    break;
            }
            return new BaseDto
           (
                IsSuccess: true,
                Message: null
            );
        }

        public bool RemoveDiscountFromBasket(int BasketId)
        {
            var basket = context.Baskets.Find(BasketId);
            basket.RemoveDiscount();
            context.SaveChanges();
            return true;
        }
    }

    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
