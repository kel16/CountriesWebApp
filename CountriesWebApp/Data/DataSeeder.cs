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

namespace CountriesWebApp.Data
{
    public class DataSeeder
    {
        public static List<string> RegionsInfo = new List<string>()
        {
            "Australia",
            "Asia",
            "Africa",
            "Europe",
            "Oceania",
            "South America"
        };

        public static List<string> CitiesInfo = new List<string>()
        {
            "Melbourn",
            "Hong Kong",
            "Peking",
            "Dresden",
            "Berlin",
            "Washington"
        };

        public static void InitializeRegions(DataContext context)
        {
            var regionList = new List<Region>();

            for (int count = 0; count < RegionsInfo.Count; count++)
            {
                regionList.Add(new Region()
                {
                    Id = count + 1,
                    Name = RegionsInfo[count]
                });
            }

            foreach (var region in regionList)
            {
                context.Regions.Add(region);
            }

            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Regions ON"); // crucial for setting explicit id
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Regions OFF");
        }

        public static void InitializeCities(DataContext context)
        {
            var cityList = new List<City>();

            for (int count = 0; count < CitiesInfo.Count; count++)
            {
                cityList.Add(new City()
                {
                    Id = count + 1,
                    Name = CitiesInfo[count]
                });
            }

            foreach (var city in cityList)
            {
                context.Cities.Add(city);
            }

            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities ON");
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities OFF");
        }

        public static void InitializeCountries(DataContext context)
        {
            var countryList = new List<Country>()
            {
                new Country
                {
                    Name = "Germany",
                    Code = "276",
                    Square = 2656.0,
                    Population = 5000,
                    //Capital = new City() { Id = 5, Name = CitiesInfo[5] },
                    CapitalId = 5,
                    //Region = new Region() {Id = 4, Name = RegionsInfo[4]},
                    RegionId = 4
                },

                new Country
                {
                    Name = "China",
                    Code = "111",
                    Square = 5769.3,
                    Population = 999,
                    //Capital = new City() { Id = 3, Name = CitiesInfo[3] },
                    CapitalId = 3,
                    //Region = new Region() {Id = 2, Name = RegionsInfo[2]},
                    RegionId = 2
                }
            };

            foreach (var country in countryList)
            {
                context.Countries.Add(country);
            }

            context.SaveChanges();
        }
    }
}