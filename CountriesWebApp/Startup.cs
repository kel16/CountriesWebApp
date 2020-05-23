using CountriesWebApp.Data.Repositories;
using CountriesWebApp.Data.Repositories.IRepositories;
using CountriesWebApp.Domain.Storages;
using CountriesWebApp.Domain.Storages.IStorages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using CountriesWebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Countries Web Application API", Version = "v1" });
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRegionStorage, RegionStorage>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityStorage, CityStorage>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryStorage, CountryStorage>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Countries Web Application V1");
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            //app.UseMvc();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Blog", action = "Index" });
            });
        }
    }
}