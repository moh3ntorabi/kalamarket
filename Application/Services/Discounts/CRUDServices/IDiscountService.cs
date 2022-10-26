using Application.Dtos;
using Application.Interfaces.Context;
using Common;
using Domain.Catalogs;
using Domain.Discounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Discounts.CRUDServices
{
    public interface IDiscountService
    {
        void AddNewDiscount(AddDiscountDto discountDto);
        PaginatedItemsDto<DiscountDto> GetList(int page, int pageSize);
        BaseDto RemoveDiscount(int Id);
    }

    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext context;

        public DiscountService(IDataBaseContext context)
        {
            this.context = context;
        }



        public void AddNewDiscount(AddDiscountDto discount)
        {
            var newdiscount = new Discount()
            {
                Name = discount.Name,
                CouponCode = discount.CouponCode,
                DiscountAmount = discount.DiscountAmount,
                DiscountLimitationId = discount.DiscountLimitationId,
                DiscountPercentage = discount.DiscountPercentage,
                DiscountTypeId = discount.DiscountTypeId,
                EndDate = discount.EndDate,
                RequiresCouponCode = discount.RequiresCouponCode,
                StartDate = discount.StartDate,
                UsePercentage = discount.UsePercentage,
            };

            if (discount.appliedToCatalogItem != null)
            {
                var catalogItems = context.CatalogItems.Where(p => discount.appliedToCatalogItem.Contains(p.Id)).ToList();
                newdiscount.CatalogItems = catalogItems;
            }

            context.Discounts.Add(newdiscount);
            context.SaveChanges();
        }

        public PaginatedItemsDto<DiscountDto> GetList(int page, int pageSize)
        {
            PersianCalendar pC = new PersianCalendar();
            int totalCount = 0;
            var result = context.Discounts
                .Include(p => p.CatalogItems)
                .PagedResult(page, pageSize, out totalCount);

            var data = result.Select(p => new DiscountDto
            {
                Id = p.Id,
                CatalogItems = p.CatalogItems.Select(c => new CatalogItemsDto
                {
                    Name = c.Name
                }).ToList(),
                RequiresCouponCode = p.RequiresCouponCode,
                CouponCode = p.CouponCode,
                DiscountAmount = p.DiscountAmount,
                DiscountLimitationId = p.DiscountLimitationId,
                DiscountPercentage = p.DiscountPercentage,
                DiscountTypeId = p.DiscountTypeId,
                EndDate = string.Format("{0}/{1}/{2}"
                     , pC.GetYear(p.EndDate.Value)
                     , pC.GetMonth(p.EndDate.Value)
                     , pC.GetDayOfMonth(p.EndDate.Value)
                     , pC.GetHour(p.EndDate.Value)
                     , pC.GetMinute(p.EndDate.Value)
                     , pC.GetSecond(p.EndDate.Value)),
                LimitationTimes = p.LimitationTimes,
                Name = p.Name,
                StartDate = string.Format("{0}/{1}/{2} {3}:{4}:{5}"
                     , pC.GetYear(p.StartDate.Value)
                     , pC.GetMonth(p.StartDate.Value)
                     , pC.GetDayOfMonth(p.StartDate.Value)
                     , pC.GetHour(p.StartDate.Value)
                     , pC.GetMinute(p.StartDate.Value)
                     , pC.GetSecond(p.StartDate.Value)),
                UsePercentage = p.UsePercentage,
            }).ToList();


            return new PaginatedItemsDto<DiscountDto>(page, pageSize, totalCount, data);
        }

        public BaseDto RemoveDiscount(int Id)
        {
            var discount = context.Discounts.Find(Id);
            if (discount == null)
            {
                return new BaseDto
                (
                    IsSuccess: false,
                    Message: "تخفیف یافت نشد"
               );
            }
            context.Discounts.Remove(discount);
            return new BaseDto
            (
                IsSuccess: true,
                Message: "تخفیف با موفقیت حذف شد"
            );

        }
    }

    public class AddDiscountDto
    {
        [Display(Name = "نام تخفیف")]
        public string Name { get; set; }
        [Display(Name = "استفاده از درصد؟")]
        public bool UsePercentage { get; set; } = true;
        [Display(Name = "درصد تخفیف")]
        public int DiscountPercentage { get; set; } = 0;
        [Display(Name = "مبلغ تخفیف")]
        public int DiscountAmount { get; set; } = 0;
        [Display(Name = "زمان شروع")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "زمان انقضا")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "استفاده از کوپن")]
        public bool RequiresCouponCode { get; set; }
        [Display(Name = "کد کوپن")]
        public string CouponCode { get; set; }
        [Display(Name = "نوع تخفیف")]
        public int DiscountTypeId { get; set; }
        [Display(Name = "محدودیت تخفیف")]
        public int DiscountLimitationId { get; set; }
        [Display(Name = "تعداد کد تخفیف")]
        public int LimitationTimes { get; set; } = 0;
        [Display(Name = "اعمال برای محصول")]
        public List<int> appliedToCatalogItem { get; set; }
    }
    public class DiscountDto
    {
        public int Id { get; set; }
        [Display(Name = "نام تخفیف")]
        public string Name { get; set; }
        [Display(Name = "استفاده از درصد؟")]
        public bool UsePercentage { get; set; } = true;
        [Display(Name = "درصد تخفیف")]
        public int DiscountPercentage { get; set; } = 0;
        [Display(Name = "مبلغ تخفیف")]
        public int DiscountAmount { get; set; } = 0;
        [Display(Name = "زمان شروع")]
        public string StartDate { get; set; }
        [Display(Name = "زمان انقضا")]
        public string EndDate { get; set; }
        [Display(Name = "استفاده از کوپن")]
        public bool RequiresCouponCode { get; set; }
        [Display(Name = "کد تخفیف")]
        public string CouponCode { get; set; }
        [Display(Name = "نوع تخفیف")]
        public int DiscountTypeId { get; set; }
        [Display(Name = "محدودیت تخفیف")]
        public int DiscountLimitationId { get; set; }

        [Display(Name = "تعداد کد تخفیف")]
        public int LimitationTimes { get; set; } = 0;
        [Display(Name = "برای محصول")]
        public List<CatalogItemsDto> CatalogItems { get; set; }
    }
    public class CatalogItemsDto
    {
        public string Name { get; set; }
    }
}
