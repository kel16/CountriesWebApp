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
    /// <para><see cref="Add(CountryModel)"/></para>
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Provides Dependency Injection
        /// </summary>
        /// <param name="context"></param>
        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns list of countries
        /// </summary>
        /// <returns></returns>
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
        /// Returns country model with the given name
        /// </summary>
        /// <param name="countryName">Given name of the country</param>
        /// <returns></returns>
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
        /// Returns country entity with the given code
        /// </summary>
        /// <param name="countryCode">Given code of the country</param>
        /// <returns></returns>
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

            return country.FirstOrDefault();
        }

        /// <summary>
        /// Saves country
        /// </summary>
        /// <param name="country">Contains country entity</param>
        /// <returns></returns>
        public async Task Add(Country country)
        {
            await context.Countries.AddAsync(country);
        }

        /// <summary>
        /// Updates country information
        /// </summary>
        /// <param name="country">Country entity to update</param>
        /// <param name="newCountry">Updated country model</param>
        /// <param name="regionId">Updated id of region</param>
        /// <param name="capitalId">Updated id of city</param>
        /// <returns></returns>
        public async Task<Country> UpdateCountry(Country country, CountryModel newCountry, Region region, City capital)
        {
            country.Name = newCountry.Name;
            country.Square = newCountry.Square;
            country.Population = newCountry.Population;
            country.Region = region;
            country.Capital = capital;
            country.RegionId = region.Id;
            country.CapitalId = capital.Id;

            context.Countries.Update(country);

            return country;
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
