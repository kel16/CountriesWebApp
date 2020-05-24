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
    /// <summary>
    /// Contains methods:
    /// <para><see cref="CityRepository()"/></para>
    /// <para><see cref="AddCity()"/></para>
    /// <para><see cref="GetCityByName()"/></para>
    /// </summary>
    public class CityRepository : ICityRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Provides Dependency Injection.
        /// </summary>
        /// <param name="context">Application database context.</param>
        public CityRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Saves city.
        /// </summary>
        /// <param name="city">City entity.</param>
        /// <returns></returns>
        public async Task AddCity(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("City");
            }

            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns city with the given name.
        /// </summary>
        /// <param name="cityName">Given name of the city.</param>
        /// <returns>City</returns>
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
    }
}
