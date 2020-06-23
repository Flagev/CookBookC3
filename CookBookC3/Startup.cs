using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookC3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using DataLibrary.Logic;
using DataLibrary.DataAccess;
using AutoMapper;
using DataLibrary.Models;

namespace CookBookC3
{
    public class Startup
    {
        IMapper mapper;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SqlDataAccess>();
            services.AddSingleton<IIngredientProcessor, IngredientProcessor>();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<IngredientModelUI, IngredientModelDTO>();
            });
            mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
                //endpoints.MapControllerRoute(
                //    name: "IngredientPagination",
                //    pattern: "Skladniki/{id:int?}",
                //    defaults: new { Controller = "Ingredients", action = "Index" }
                //    );
                //endpoints.MapControllerRoute(
                //    name: "Ingredient",
                //    pattern: "Skladniki/{action}/{id?}",
                //    defaults: new { Controller = "Ingredients"}
                //    );
                endpoints.MapControllerRoute(
                    name: "Category",
                    pattern: "Skladniki/{category}/{id?}",
                    defaults: new { Controller = "Ingredients", action="Index" }
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
