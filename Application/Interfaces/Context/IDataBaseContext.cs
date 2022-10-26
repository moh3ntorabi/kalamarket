using Domain.Banners;
using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
using Domain.Orders;
using Domain.Payments;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogItemFavourite> CatalogItemFavourites { get; set; }
        DbSet<CatalogItamComment> CatalogItamComments { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        DbSet<Banner> Banners { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry Entry([NotNullAttribute] object entity);
    }
}
