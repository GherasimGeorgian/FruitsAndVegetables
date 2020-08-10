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

namespace FruitsAndVegetables
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot _configurationRoot;
        private string _contentRootPath = "";// string con set
        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            _contentRootPath = hostingEnvironment.ContentRootPath;// string con set
        }
        public void ConfigureServices(IServiceCollection services)
        {

            
            

            string conn = _configurationRoot.GetConnectionString("DefaultConnection");// string con set
           // if (conn.Contains("%CONTENTROOTPATH%"))
         //   {
         //       conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
         //   }

            //server configuration
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(conn));

            //services.AddTransient<IProductRepository,MockProductRepository>();
            //services.AddTransient<ICategoryRepository,MockCategoryRepository>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<ICategoryRepository,CategoryRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            

            DbInitializer.Seed(serviceProvider);
        }
    }
}
