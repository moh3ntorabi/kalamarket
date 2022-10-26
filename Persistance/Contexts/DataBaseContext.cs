using Application.Interfaces.Context;
using Domain.Attributes;
using Domain.Banners;
using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
using Domain.Orders;
using Domain.Payments;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityConfiguration;
using Persistance.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class DataBaseContext:DbContext,IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItemFavourite> CatalogItemFavourites { get; set; }
        public DbSet<CatalogItamComment> CatalogItamComments { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }

        public DbSet<Banner> Banners { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute),true).Length>0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            modelBuilder.Entity<CatalogType>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<BasketItem>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<Basket>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<CatalogBrand>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            

            modelBuilder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());

            


            DataBaseContextSeed.CatalogSeed(modelBuilder);

            modelBuilder.Entity<Order>().OwnsOne(p => p.Address);

            modelBuilder.Entity<Order>().Property(p => p.DiscountAmount)
                .HasColumnType("decimal(18, 4)");

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(p=>p.State==EntityState.Added ||
                p.State == EntityState.Modified ||
                p.State == EntityState.Deleted);
            foreach (var item in modifiedEntities)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType != null)
                {
                    var inserted = entityType.FindProperty("InsertTime");
                    var updated = entityType.FindProperty("UpdateTime");
                    var removed = entityType.FindProperty("RemoveTime");
                    var isRemoved = entityType.FindProperty("IsRemoved");
                    if (item.State == EntityState.Added && inserted != null)
                    {
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    }
                    if (item.State == EntityState.Modified && updated != null)
                    {
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }
                    if (item.State == EntityState.Deleted && removed != null && isRemoved != null)
                    {
                        item.State = EntityState.Unchanged;
                        item.Property("RemoveTime").CurrentValue = DateTime.Now;
                        item.Property("IsRemoved").CurrentValue = true;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
