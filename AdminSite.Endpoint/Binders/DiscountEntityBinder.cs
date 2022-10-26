using Application.Services.Discounts.CRUDServices;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSite.Endpoint.Binders
{
    public class DiscountEntityBinder: IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }




            AddDiscountDto discountDto = new AddDiscountDto()
            {
                CouponCode = bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.CouponCode)}").Values.ToString(),


                DiscountAmount = int.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.DiscountAmount)}").Values.ToString()),

                DiscountLimitationId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),


                DiscountPercentage = int.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),

                DiscountTypeId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.DiscountTypeId)}").Values.ToString()),
                LimitationTimes = int.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.LimitationTimes)}").Values.ToString()),

                UsePercentage = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.UsePercentage)}").FirstValue.ToString()),

                Name = bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.Name)}").Values.ToString(),

                RequiresCouponCode = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.RequiresCouponCode)}").FirstValue.ToString()),

                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.EndDate)}").Values.ToString()),

                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.StartDate)}").Values.ToString()),
            };


            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("appliedToCatalogItem");

            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                discountDto.appliedToCatalogItem =
                bindingContext.ValueProvider
                .GetValue($"{nameof(discountDto.appliedToCatalogItem)}")
                .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            }


            bindingContext.Result = ModelBindingResult.Success(discountDto);
            return Task.CompletedTask;
        }

    }
}
