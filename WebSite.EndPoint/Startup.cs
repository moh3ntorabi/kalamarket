using Application.Interfaces.Context;
using Application.Services.Baskets;
using Application.Services.Catalogs.CatalogItems.CatalogItemServices;
using Application.Services.Catalogs.CatalogItems.GetCatalogItemPDP;
using Application.Services.Catalogs.CatalogItems.GetCatalogItemPLP;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using Application.Services.Catalogs.GetMenuItem;
using Application.Services.Comment.Commands;
using Application.Services.Discounts;
using Application.Services.HomePages;
using Application.Services.Orders;
using Application.Services.Orders.CustomerOrderService;
using Application.Services.Payments;
using Application.Services.Users;
using Application.Services.Visitors.SaveVisitorInfo;
using Application.Services.Visitors.VisitorOnline;
using Infrastructure.IdentityConfigs;
using Infrastructure.MappingProfile;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.Contexts;
using Persistance.Contexts.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.EndPoint.Hubs;
using WebSite.EndPoint.Utilities.Filters;
using WebSite.EndPoint.Utilities.MiddleWares;

namespace WebSite.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMediatR(typeof(SendCommentCommand).Assembly);
            
            #region ConnectionString
            services.AddTransient<IDataBaseContext, DataBaseContext>();
            services.AddTransient<IIdentityDataBaseContext, IdentityDataBaseContext>();
            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection));

            services.AddDistributedSqlServerCache(option =>
            {
                option.ConnectionString = connection;
                option.SchemaName = "dbo";
                option.TableName = "CacheData";
            });

            services.AddIdentityService(Configuration);
            services.AddAuthentication();
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });
            #endregion

            services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
            services.AddTransient<IVisitorOnlineService, VisitorOnlineService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IUriComposerService, UriComposerService>();
            services.AddTransient<IHomePageService, HomePageService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IDiscountBasketService,DiscountBasketService>();
            services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
            services.AddTransient<ICatalogItemService, CatalogItemService>();
            services.AddTransient<IGetMenuItemService, GetMenuItemService>();
            services.AddTransient<IGetCatalogItemPLPService, GetCatalogItemPLPService>();
            services.AddTransient<IGetCatalogItemPDPService, GetCatalogItemPDPService>();
            services.AddTransient<ICustomerOrderService, CustomerOrderService>();
            services.AddScoped<SaveVisitorFilter>();
            services.AddSignalR();

            services.AddAutoMapper(typeof(CatalogMappingProfile));
            services.AddAutoMapper(typeof(UserMappingProfile));

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSetVisitorId();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "ProductDetail",
                    pattern: "product/{id}",
                    defaults:new {controller="Product",action="Detail"});
                
                

                endpoints.MapHub<OnlineVisitorHub>("/chathub");
            });
        }
    }
}
