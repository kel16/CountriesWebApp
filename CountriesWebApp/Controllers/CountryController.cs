using CountriesWebApp.Models.Data;
using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Domain.Storages.IStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace CountriesWebApp.Controllers
{
    /// <summary>
    /// Provides methods for listing countries, getting the country by name and adding country.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryStorage countryStorage;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="countryStorage">Country storage.</param>
        public CountriesController(ICountryStorage countryStorage)
        {
            this.countryStorage = countryStorage;
        }

        /// <summary>
        /// Returns list of countries.
        /// </summary>
        /// <param name="page">Current page number.</param>
        /// <param name="quantity">Number of items per page.</param>
        /// <returns>List of country models.</returns>
        [HttpGet("get-countries")]
        public ListCountryModels GetCountries(int page = 1, int quantity = 10)
        {
            try
            {
                return countryStorage.GetCountries(page, quantity);
            }
            catch (Exception e)
            {
                throw new Exception($"Невозможно извлечь страны из-за ошибки: {e.Message}");
            }
        }
        
        /// <summary>
        /// Returns country with the given name.
        /// </summary>
        /// <param name="name">Given name of the country.</param>
        /// <returns>Country model.</returns>
        [HttpGet("get-country")]
        public async Task<CountryModel> GetCountryByName([Required] string name)
        {
            try
            {
                return await countryStorage.GetCountryByName(name);
            }
            catch (Exception e)
            {
                throw new Exception($"Невозможно найти страну из-за ошибки: {e.Message}");
            }
        }

        /// <summary>
        /// Adds new country or updates existing one.
        /// </summary>
        /// <param name="country">Contains given information about country.</param>
        /// <returns></returns>
        [HttpPost("add-country")]
        public async Task AddCountry([FromBody]CountryModel country)
        {
            try
            {
                await countryStorage.AddCountry(country);
            }
            catch (Exception e)
            {
                throw new Exception($"Невозможно добавить страну из-за ошибки: {e.Message}");
            }
        }
    }
}