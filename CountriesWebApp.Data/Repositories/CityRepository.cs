using CountriesWebApp;
using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using CountriesWebApp.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Provides Dependency Injection
        /// </summary>
        /// <param name="context"></param>
        public CityRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Saves city
        /// </summary>
        /// <param name="city">City entity</param>
        /// <returns></returns>
        public async Task AddCity(City city)
        {
            await context.Cities.AddAsync(city);
        }

        /// <summary>
        /// Returns city with the given name
        /// </summary>
        /// <param name="cityName">Given name of the city</param>
        /// <returns></returns>
        public async Task<City> GetCityByName(string cityName)
        {
            var city = from c in context.Cities
                         where c.Name == cityName
                         select new City
                         {
                             Id = c.Id,
                             Name = c.Name,
                         };

            return city.FirstOrDefault();
        }

        /// <summary>
        /// Saves changes to DB
        /// </summary>
        /// <returns></returns>
        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
