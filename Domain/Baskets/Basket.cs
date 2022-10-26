using Domain.Attributes;
using Domain.Catalogs;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    [Auditable]
    public class Basket
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public ICollection<BasketItem> Items => _items.AsReadOnly();

        public int DiscountAmount { get; set; }
        public Discount AppliedDiscount { get; set; }
        public int? AppliedDiscountId { get; set; }

        public Basket(string buyerId)
        {
            this.BuyerId = buyerId;
        }
        public void AddItem(int unitPrice, int quantity, int catalogItemId)
        {
            if (!Items.Any(p => p.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(unitPrice, catalogItemId, quantity));
                return;
            }
            var existingItem = Items.FirstOrDefault(p => p.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        public int TotalPrice()
        {
            var totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            return totalPrice;
        }
        public int TotalPriceWithoutDiscount()
        {
            var totalPrice = _items.Sum(p => p.UnitPrice * p.Quantity);
            return totalPrice;
        }

        public void AppliedDiscountCode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(TotalPriceWithoutDiscount());
        }
        public void RemoveDiscount()
        {
            AppliedDiscountId = null;
            AppliedDiscount = null;
            DiscountAmount = 0;
        }
    }
    [Auditable]
    public class BasketItem
    {
        public int Id { get; set; }
        public int UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public CatalogItem CatalogItem { get; private set; }
        public int BasketId { get; private set; }
        public BasketItem(int unitPrice, int quantity, int catalogItemId)
        {
            UnitPrice = unitPrice;
            CatalogItemId = catalogItemId;
            SetQuantity(quantity);
        }
        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }
        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
