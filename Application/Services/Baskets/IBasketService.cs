using Application.Interfaces.Context;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Baskets
{
    public interface IBasketService
    {
        BasketDto GetOrCreateBasketForUser(string BuyerId);
        void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1);
        bool RemoveItemFromBasket(int ItemId);
        bool SetQuantities(int itemId, int quantity);
        BasketDto GetBasketForUser(string UserId);
        void TransferBasket(string anonymousId, string UserId);
    }

    public class BasketService : IBasketService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposer;
        public BasketService(IDataBaseContext context, IUriComposerService uriComposer)
        {
            this.context = context;
            this.uriComposer = uriComposer;
        }
        public void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1)
        {
            var basket=context.Baskets.FirstOrDefault(p=>p.Id==basketId);
            if (basket == null)
                throw new Exception("");

            var catalog = context.CatalogItems.Find(catalogItemId);
            basket.AddItem(catalog.Price, quantity, catalogItemId);
            context.SaveChanges();
        }

        public BasketDto GetBasketForUser(string UserId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(p => p.BuyerId == UserId);
            if (basket == null)
            {
                return null;
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(items => new BasketItemDto
                {
                    Id = items.Id,
                    CatalogItemId = items.CatalogItemId,
                    CatalogName = items.CatalogItem.Name,
                    Quantity = items.Quantity,
                    UnitPrice = items.UnitPrice,
                    ImageUrl = uriComposer.ComposeImageUri(items?.CatalogItem?.CatalogItemImages?
                    .FirstOrDefault()?.Src ?? ""),
                }).ToList(),
            };
        }

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket=context.Baskets
                .Include(p=>p.Items)
                .ThenInclude(p=>p.CatalogItem)
                .ThenInclude(p=>p.CatalogItemImages)
                .SingleOrDefault(p=>p.BuyerId==BuyerId);
            if (basket==null)
            {
                return CreateBasketForUser(BuyerId);
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(items => new BasketItemDto
                {
                    Id = items.Id,
                    CatalogItemId = items.CatalogItemId,
                    CatalogName = items.CatalogItem.Name,
                    Quantity = items.Quantity,
                    UnitPrice = items.UnitPrice,
                    ImageUrl = uriComposer.ComposeImageUri(items?.CatalogItem?.CatalogItemImages?
                    .FirstOrDefault()?.Src ?? ""),
                }).ToList(),
            };
        }
        private BasketDto CreateBasketForUser(string buyerId)
        {
            Basket basket = new Basket(buyerId);
            context.Baskets.Add(basket);
            context.SaveChanges();
            return new BasketDto
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id
            };
        }
        public bool RemoveItemFromBasket(int ItemId)
        {
            var item= context.BasketItems.SingleOrDefault(p=>p.Id==ItemId);
            context.BasketItems.Remove(item);
            context.SaveChanges();
            return true;
        }

        public bool SetQuantities(int itemId, int quantity)
        {
            var item = context.BasketItems.SingleOrDefault(p => p.Id == itemId);
            item.SetQuantity(quantity);
            context.SaveChanges();
            return true;
        }

        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket=context.Baskets.FirstOrDefault(p=>p.BuyerId== anonymousId);
            if (anonymousBasket == null) return;
            var userBasket = context.Baskets.FirstOrDefault(p => p.BuyerId == UserId);
            if (userBasket==null)
            {
                userBasket = new Basket(UserId);
                context.Baskets.Add(userBasket);
            }
            foreach (var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.UnitPrice,item.Quantity,item.CatalogItemId);
            }
            context.Baskets.Remove(anonymousBasket);
            context.SaveChanges();
        }
    }

    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public int DiscountAmount { get; set; }

        public int Total()
        {
            if (Items.Count > 0)
            {
                int total = Items.Sum(p => p.UnitPrice * p.Quantity);
                total -= DiscountAmount;
                return total;
            }
            return 0;
        }
        public int TotalWithOutDiscount()
        {
            if (Items.Count > 0)
            {
                int total = Items.Sum(p => p.UnitPrice * p.Quantity);
                return total;
            }
            return 0;
        }
    }

    public class BasketItemDto
    {
        public int Id { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CatalogItemId { get; set; }
        public string CatalogName { get; set; }
        public string ImageUrl { get; set; }
    }
}
