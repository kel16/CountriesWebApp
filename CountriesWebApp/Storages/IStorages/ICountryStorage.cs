using CountriesWebApp.Data;
using CountriesWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Storages.IStorages
{
    public interface ICountryStorage
    {
        /// <summary>
        /// Returns full list of countries
        /// </summary>
        /// <returns></returns>
        Task<List<CountryModel>> GetCountries();

        /// <summary>
        /// Returns country model with the given name
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<CountryModel> GetCountryByName(string countryName);

        /// <summary>
        /// Returns country model with the given code
        /// </summary>
        /// <param name="countryCode">Given country code</param>
        /// <returns></returns>
        Task<Country> GetCountryByCode(string countryCode);

        /// <summary>
        /// Updates country
        /// </summary>
        /// <param name="country">Country entity to update</param>
        /// <param name="newCountryModel">Country model with new information</param>
        /// <param name="regionId">New region id</param>
        /// <param name="CityId">New city if</param>
        /// <returns></returns>
        Task UpdateCountry(Country country, CountryModel newCountryModel, int regionId, int CityId);

        /// <summary>
        /// Adds new country
        /// </summary>
        /// <param name="country">Country model</param>
        /// <returns></returns>
        Task AddCountry(Country country); 
    }
}
