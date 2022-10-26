using AdminSite.Endpoint.MappingProfile;
using Application.Interfaces.Context;
using Application.Services.Banners;
using Application.Services.Catalogs.CatalogBrands;
using Application.Services.Catalogs.CatalogItems.AddNewCatalogItem;
using Application.Services.Catalogs.CatalogItems.CatalogItemServices;
using Application.Services.Catalogs.CatalogItems.UriComposer;
using Application.Services.Catalogs.CatalogTypes.CRUDService;
using Application.Services.Discounts;
using Application.Services.Discounts.CRUDServices;
using Application.Services.Visitors.GetTodayReport;
using Infrastructure.ExternalApi.ImageServer;
using Infrastructure.MappingProfile;
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

namespace AdminSite.Endpoint
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
            services.AddControllers();
            services.AddScoped<IGetTodayReportService, GetTodayReportService>();
            services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
            services.AddTransient<ICatalogTypeService, CatalogTypeService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IAddNewCatalogItemService, AddNewCatalogItemService>();
            services.AddTransient<ICatalogItemService, CatalogItemService>();
            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddTransient<IDiscountService,DiscountService >();
            services.AddTransient<IDiscountBasketService, DiscountBasketService>();
            services.AddTransient<IDiscountHistoryService, DiscountHistoryService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<IUriComposerService, UriComposerService>();

            #region connection String SqlServer
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            string connection = Configuration["ConnectionString:SqlServer"];
            services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
            #endregion
            //mapping
            services.AddAutoMapper(typeof(CatalogMappingProfile));
            services.AddAutoMapper(typeof(CatalogVMMappingProfile));
            services.AddAutoMapper(typeof(BannerMappingProfile));
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
