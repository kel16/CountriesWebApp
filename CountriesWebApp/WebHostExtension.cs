using CountriesWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp
{
    public static class WebHostExtension
    {
        /// <summary>
        /// Creates database scheme.
        /// </summary>
        /// <param name="webHost"></param>
        /// <returns></returns>
        public static IWebHost Migrate(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.Migrate();
            }

            return webHost;
        }

        /// <summary>
        /// Inserts data into database.
        /// </summary>
        /// <param name="webHost"></param>
        /// <returns></returns>
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
                    if (!context.Cities.Any())
                    {
                        DataSeeder.InitData(context);
                    }
                    
                    context.Database.CommitTransaction();
                }
                catch (Exception)
                {
                    context.Database.RollbackTransaction();
                }
            }

            return webHost;
        }
    }
}
