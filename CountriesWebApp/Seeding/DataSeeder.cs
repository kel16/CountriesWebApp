using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using CountriesWebApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CountriesWebApp.Seeding
{
    /// <summary>
    /// Initializes database with data.
    /// </summary>
    public class DataSeeder
    {
        /// <summary>
        /// Inserts into database new regions, cities and countries.
        /// </summary>
        /// <param name="context">Application database context.</param>
        public static void InitData(DataContext context)
        {
            int cityCount = 0; // Region's and city's current IDs.
            Country newCountry; // Instance of country that is being added.
            Region matchedRegion; // Instance of region that matches country.
            List<CountryModelAPI> countries = DataInformation.LoadData(); // Loads list of countries from resource.

            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities ON");
            foreach (CountryModelAPI country in countries)
            {
                newCountry = new Country()
                {
                    Name = country.Name,
                    Code = country.Alpha2Code,
                    Population = country.Population,
                    Area = country.FormattedArea,
                };

                if (country.Capital != "")
                {
                    context.Cities.Add(new City() { Id = ++cityCount, Name = country.Capital });

                    newCountry.CapitalId = cityCount;
                }

                if (country.Region != "")
                {
                    matchedRegion = context.Regions.Where(r => r.Name.ToUpper() == country.Region.Trim().ToUpper()).FirstOrDefault();

                    if (matchedRegion == null)
                    {
                        context.Regions.Add(new Region() { Name = country.Region });
                        context.SaveChanges();
                        matchedRegion = context.Regions.Where(r => r.Name.ToUpper() == country.Region.ToUpper()).FirstOrDefault();
                    }

                    newCountry.RegionId = matchedRegion.Id;
                }

                context.Countries.Add(newCountry);
            };

            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities OFF");
        }
    }
}