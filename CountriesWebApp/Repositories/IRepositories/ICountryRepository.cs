using CountriesWebApp.Data;
using CountriesWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Repositories.IRepositories
{
    public interface ICountryRepository : IRepository
    {
        /// <summary>
        /// Returns list of countries
        /// </summary>
        /// <returns></returns>
        Task<List<CountryModel>> GetCountries();

        /// <summary>
        /// Returns country with the given name
        /// </summary>
        /// <param name="countryName">Given name of the country</param>
        /// <returns></returns>
        Task<CountryModel> GetCountryByName(string countryName);

        /// <summary>
        /// Returns country with the given code
        /// </summary>
        /// <param name="countryCode">Given code of the country</param>
        /// <returns></returns>
        Task<Country> GetCountryByCode(string countryCode);

        /// <summary>
        /// Saves country
        /// </summary>
        /// <param name="country">Contains country entity</param>
        /// <returns></returns>
        Task Add(Country country);

        /// <summary>
        /// Updates country information
        /// </summary>
        /// <param name="country">Country entity to update</param>
        /// <param name="newCountry">Updated country model</param>
        /// <param name="regionId">Updated id of region</param>
        /// <param name="capitalId">Updated id of city</param>
        /// <returns></returns>
        Task<Country> UpdateCountry(Country country, CountryModel newCountry, int regionId, int capitalId);
    }
}
