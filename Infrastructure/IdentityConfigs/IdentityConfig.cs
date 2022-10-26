using Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IdentityConfigs
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration)
        {
            string connection = configuration["ConnectionString:SqlServer"];

            services.AddDbContext<IdentityDataBaseContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataBaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityErrors>();

            services.Configure<IdentityOptions>(option =>
            {
                //UserSetting
                //option.User.AllowedUserNameCharacters = "abcd123";
                option.User.RequireUniqueEmail = true;

                //Password Setting
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;//!@#$%^&*()_+
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 8;
                option.Password.RequiredUniqueChars = 1;

                //Lokout Setting
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(30);
            });

                return services;

        }
    }
}
