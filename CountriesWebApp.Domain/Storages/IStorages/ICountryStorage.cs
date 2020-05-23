﻿using CountriesWebApp.Models.Data;
using CountriesWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Domain.Storages.IStorages
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
        /// <param name="regionId">New region entity</param>
        /// <param name="CityId">New city entity</param>
        /// <returns></returns>
        Task UpdateCountry(Country country, CountryModel newCountryModel, Region regionId, City CityId);

        /// <summary>
        /// Adds new country
        /// </summary>
        /// <param name="country">Country model</param>
        /// <returns></returns>
        Task AddCountry(Country country); 
    }
}