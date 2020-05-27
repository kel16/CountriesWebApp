using CountriesWebApp.Models.Data;
using CountriesWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories.IRepositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetCountries()"/></para>
    /// <para><see cref="GetCountryByName(string)"/></para>
    /// <para><see cref="GetCountryByCode(string)"/></para>
    /// <para><see cref="AddCountry(Country)"/></para>
    /// <para><see cref="UpdateCountry(Country, CountryModel, Region, City)"/></para>
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Returns list of countries.
        /// </summary>
        /// <param name="page">Current page number.</param>
        /// <param name="quantity">Number of items per page.</param>
        /// <returns>List of country models.</returns>
        ListCountryModels GetCountries(int page, int quantity);

        /// <summary>
        /// Returns country view model with the given name.
        /// </summary>
        /// <param name="countryName">Given name of the country.</param>
        /// <returns>Country model.</returns>
        Task<CountryModel> GetCountryByName(string countryName);

        /// <summary>
        /// Returns country entity with the given code.
        /// </summary>
        /// <param name="countryCode">Given code of the country.</param>
        /// <returns>Country entity.</returns>
        Task<Country> GetCountryByCode(string countryCode);

        /// <summary>
        /// Saves country.
        /// </summary>
        /// <param name="country">Contains country entity.</param>
        /// <returns></returns>
        Task AddCountry(Country country);

        /// <summary>
        /// Updates country information in database.
        /// </summary>
        /// <param name="country">Country entity.</param>
        /// <returns>Country entity</returns>
        Task<Country> UpdateCountry(Country country);
    }
}
