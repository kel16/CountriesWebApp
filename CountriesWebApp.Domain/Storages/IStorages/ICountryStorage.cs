using CountriesWebApp.Models.Data;
using CountriesWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Domain.Storages.IStorages
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetCountries()"/></para>
    /// <para><see cref="GetCountryByCode(string)"/></para>
    /// <para><see cref="AddCountry(CountryModel)"/></para>
    /// </summary>
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
        /// Adds new country.
        /// </summary>
        /// <param name="country">Country model.</param>
        /// <returns></returns>
        Task AddCountry(CountryModel countryModel);
    }
}
