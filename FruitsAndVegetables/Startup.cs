using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitsAndVegetables.Data.interfaces;
using FruitsAndVegetables.Data.mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FruitsAndVegetables.Data;
using Microsoft.EntityFrameworkCore;
using FruitsAndVegetables.Data.Repositories;
using FruitsAndVegetables.Data.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing.Template;

namespace FruitsAndVegetables
{
    public class Startup
    {
        //Install-Package Microsoft.AspNetCore.Session
        private IConfigurationRoot _configurationRoot;

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {

            
            //server configuration
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
           
            //services.AddTransient<IProductRepository,MockProductRepository>();
            //services.AddTransient<ICategoryRepository,MockCategoryRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();

        
            //     services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
            services.AddHttpContextAccessor();

            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}",defaults: new { Controller = "Product", action = "List" });
                routes.MapRoute(name: "default", template: "{Controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Seed(serviceProvider);
        }
    }
}
