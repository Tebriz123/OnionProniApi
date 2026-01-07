using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionPronia.Appilication.Interfaces.Repositories;
using OnionPronia.Appilication.Interfaces.Services;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistence.DAL;
using OnionPronia.Persistence.Implementations.Repositories;
using OnionPronia.Persistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistence
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(opt=>
            opt.UseSqlServer(config.GetConnectionString("Default"))
            );

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 0;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();



            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IColorService, ColorService>();
            return services;
        }
        
    }
}
