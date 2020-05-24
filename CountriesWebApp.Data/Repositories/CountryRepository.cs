using CountriesWebApp.Data.Repositories.IRepositories;
using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetCountries()"/></para>
    /// <para><see cref="GetCountryByName(string)"/></para>
    /// <para><see cref="GetCountryByCode(string)"/></para>
    /// <para><see cref="AddCountry(Country)"/></para>
    /// <para><see cref="UpdateCountry(Country, CountryModel, Region, City)"/></para>
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Provides Dependency Injection.
        /// </summary>
        /// <param name="context">Aplication database context.</param>
        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns list of countries.
        /// </summary>
        /// <returns>List country view models</returns>
        public async Task<List<CountryModel>> GetCountries()
        {
            var countries = context.Countries
                   .Select(c => new CountryModel {
                       Id = c.Id,
                       Name = c.Name,
                       Code = c.Code,
                       Square = c.Square,
                       Population = c.Population,
                       Region = c.Region.Name,
                       Capital = c.Capital.Name,
                   }).ToListAsync();

            return await countries;
        }

        /// <summary>
        /// Returns country model with the given name.
        /// </summary>
        /// <param name="countryName">Given name of the country.</param>
        /// <returns>Country model</returns>
        public async Task<CountryModel> GetCountryByName(string countryName)
        {
            var country = from c in context.Countries
                           where c.Name == countryName
                           select new CountryModel
                            {
                               Id = c.Id,
                               Name = c.Name,
                               Code = c.Code,
                               Square = c.Square,
                               Population = c.Population,
                               Region = c.Region.Name,
                               Capital = c.Capital.Name,
                           };

            return country.FirstOrDefault();
        }

        /// <summary>
        /// Returns country entity with the given code.
        /// </summary>
        /// <param name="countryCode">Given code of the country.</param>
        /// <returns>Country entity</returns>
        public async Task<Country> GetCountryByCode(string countryCode)
        {
            var country = from c in context.Countries
                          where c.Code == countryCode
                          select new Country
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Code = c.Code,
                              Square = c.Square,
                              Population = c.Population,
                              Region = c.Region,
                              Capital = c.Capital,
                          };

            return await country.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Saves country to database.
        /// </summary>
        /// <param name="country">Contains country entity.</param>
        /// <returns></returns>
        public async Task AddCountry(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("Country");
            }

            await context.Countries.AddAsync(country);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates country information in database.
        /// </summary>
        /// <param name="country">Country entity.</param>
        /// <returns>Country entity</returns>
        public async Task<Country> UpdateCountry(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("Country");
            }

            /*country.Name = newCountry.Name;
            country.Square = newCountry.Square;
            country.Population = newCountry.Population;
            country.Region = newCountry.Region;
            country.Capital = newCountry.Capital;*/
            //country.RegionId = newCountry.Region.Id;
            //country.CapitalId = newCountry.Capital.Id;

            context.Countries.Update(country);
            context.SaveChanges();

            return country;
        }
    }
}
