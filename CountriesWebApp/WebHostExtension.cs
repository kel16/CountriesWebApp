﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data
{
    public static class WebHostExtension
    {
        public static IWebHost Migrate(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }

            return webHost;
        }

        public static IWebHost SeedingData(this IWebHost webHost)
        {
            var serviceScope = webHost.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            var context = services.GetService<DataContext>();
            var hostingEnvironment = services.GetService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();

            if (hostingEnvironment.EnvironmentName == "Development")
            {
                context.Database.BeginTransaction();
                try
                {
                    if (!context.Regions.Select(mt => mt.Name).Any(mt => DataSeeder.RegionsInfo.Contains(mt)))
                        DataSeeder.InitRegions(context);

                    context.SaveChanges();
                    context.Database.CommitTransaction();
                }
                catch (Exception ex)
                {
                    context.Database.RollbackTransaction();
                }
            }

            return webHost;
        }
    }
}
