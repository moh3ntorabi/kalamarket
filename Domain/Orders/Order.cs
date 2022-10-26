using Domain.Attributes;
using Domain.Catalogs;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    [Auditable]
    public class Order
    {
        public Order()
        {

        }
        public int Id { get; set; }
        public string UserId { get;private set; }
        public Address Address { get;private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public PaymentMethod PaymentMethod { get;private set; }
        public PaymentStatus PaymentStatus { get;private set; }
        public OrderStatus OrderStatus { get;private set; }
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal DiscountAmount { get; private set; }
        public Discount AppliedDiscount{ get;private set; }
        public int? AppliedDiscountId { get;private set; }

        public Order(string userId, Address address
            ,List<OrderItem> orderItems
            , PaymentMethod paymentMethod
            , Discount discount)
        {
            this.UserId = userId;
            this.Address = address;
            this.PaymentMethod = paymentMethod;
            _orderItems = orderItems;
            if (discount!=null)
            {
                Applydiscountcode(discount);
            };
        }
        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        public void PaymentDone()
        {
            PaymentStatus = PaymentStatus.Paid;
        }


        /// <summary>
        /// کالا تحویل داده شد
        /// </summary>
        public void OrderDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }

        /// <summary>
        /// ثبت مرجوعی کالا
        /// </summary>
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }


        /// <summary>
        /// لغو سفارش
        /// </summary>
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

        public int totalprice()
        {
            int totalprice = _orderItems.Sum(p => p.UnitPrice * p.Unit);
            if (AppliedDiscount != null)
            {
                totalprice -= AppliedDiscount.GetDiscountAmount(totalprice);
            }
            return totalprice;
        }

        /// <summary>
        /// دریافت مبلغ کل بدونه در نظر گرفتن کد تخفیف
        /// </summary>
        /// <returns></returns>
        public int totalpricewithoutdiescount()
        {
            int totalprice = _orderItems.Sum(p => p.UnitPrice * p.Unit);
            return totalprice;
        }

        public void Applydiscountcode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(totalprice());
        }
    }

    [Auditable]
    public class OrderItem
    {
        public int Id { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get;private set; }
        public string ProductName { get;private set; }
        public string PictureUri { get;private set; }
        public int UnitPrice { get;private set; }
        public int Unit { get;private set; }
        public OrderItem(int catalogItemId, string productName
            , string pictureUri, int unitPrice, int unit)
        {
            this.CatalogItemId = catalogItemId;
            ProductName = productName;
            PictureUri = pictureUri;
            UnitPrice = unitPrice;
            Unit = unit;
        }
        public OrderItem()
        {

        }
    }

    public class Address
    {
        public string City { get;private set; }
        public string State { get;private set; }
        public string ZipCode { get;private set; }
        public string PostalAddress { get;private set; }
        public string ReceiverName { get;private set; }
        public Address(string city, string state, string zipCode, string postalAddress, string receiverName)
        {
            this.City = city;
            State = state;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
            ReceiverName = receiverName;
        }

        
    }

    public enum PaymentMethod
    {
        OnlinePayment=0,
        PaymentInTheSpot=1,
    }
    public enum PaymentStatus
    {
        WaitingForPayment=0,
        Paid=1,
    }
    public enum OrderStatus
    {
        Processing=0,
        Delivered=1,
        Returned=2,
        Cancelled=3,
    }
}
