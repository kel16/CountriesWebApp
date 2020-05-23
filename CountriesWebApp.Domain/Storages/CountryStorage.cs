using CountriesWebApp.Domain.Storages.IStorages;
using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using CountriesWebApp.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Domain.Storages
{
    public class CountryStorage : ICountryStorage
    {
        private readonly ICountryRepository countryRepository;

        public CountryStorage(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        /// <summary>
        /// Returns full list of countries
        /// </summary>
        /// <returns></returns>
        public async Task<List<CountryModel>> GetCountries()
        {
            var countries = await countryRepository.GetCountries();

            return countries;
        }

        /// <summary>
        /// Returns country model with the given code
        /// </summary>
        /// <param name="countryCode">Given country code</param>
        /// <returns></returns>
        public async Task<Country> GetCountryByCode(string countryCode)
        {
            return await countryRepository.GetCountryByCode(countryCode);
        }

        /// <summary>
        /// Returns country model with the given name
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public async Task<CountryModel> GetCountryByName(string countryName)
        {
            return await countryRepository.GetCountryByName(countryName);
        }

        /// <summary>
        /// Updates country
        /// </summary>
        /// <param name="country">Country entity to update</param>
        /// <param name="newCountryModel">Country model with new information</param>
        /// <param name="regionId">New region entity</param>
        /// <param name="CityId">New city entity</param>
        /// <returns></returns>
        public async Task UpdateCountry(Country country, CountryModel newCountryModel, Region regionId, City CityId)
        {
            var countryUpdated = countryRepository.UpdateCountry(country, newCountryModel, regionId, CityId);

            await countryRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Adds new country
        /// </summary>
        /// <param name="country">Country model</param>
        /// <returns></returns>
        public async Task AddCountry(Country country)
        {
            await countryRepository.Add(country);

            await countryRepository.SaveChangesAsync();
        }
    }
}
