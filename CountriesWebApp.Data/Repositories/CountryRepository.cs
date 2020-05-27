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
        /// <param name="page">Current page number.</param>
        /// <param name="quantity">Number of items per page.</param>
        /// <returns>List of country models.</returns>
        public ListCountryModels GetCountries(int page, int quantity)
        {
            var countries = context.Countries
                   .Skip((page - 1) * quantity)
                   .Take(quantity)
                   .Select(c => new CountryModel {
                       Id = c.Id,
                       Name = c.Name,
                       Code = c.Code,
                       Area = c.Area,
                       Population = c.Population,
                       Region = c.Region.Name,
                       Capital = c.Capital.Name,
                   }).OrderBy(c => c.Id).ToList();

            return new ListCountryModels() { Countries = countries, Total = context.Countries.Count() };
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
                               Area = c.Area,
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
                          where c.Code.ToUpper() == countryCode.ToUpper()
                          select new Country
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Code = c.Code,
                              Area = c.Area,
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

            context.Countries.Update(country);
            context.SaveChanges();

            return country;
        }
    }
}
