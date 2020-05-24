using CountriesWebApp.Enums;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryStorage countryStorage;
        private readonly ICityStorage cityStorage;
        private readonly IRegionStorage regionStorage;

        public CountriesController(ICountryStorage countryStorage, ICityStorage cityStorage, IRegionStorage regionStorage)
        {
            this.countryStorage = countryStorage;
            this.cityStorage = cityStorage;
            this.regionStorage = regionStorage;
        }

        /// <summary>
        /// Returns list of all countries
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-countries")]
        [AllowAnonymous]
        public async Task<List<CountryModel>> GetCountries()
        {
            var countries = await countryStorage.GetCountries();

            return countries;
        }

        /// <summary>
        /// Returns country with the given name
        /// </summary>
        /// <param name="name">Given name of the country</param>
        /// <returns></returns>
        [HttpGet("get-country")]
        [AllowAnonymous]
        public async Task<CountryModel> GetCountryByName([Required] string name)
        {
            var country = await countryStorage.GetCountryByName(name);

            return country;
        }

        /// <summary>
        /// Adds new country or updates existing one
        /// </summary>
        /// <param name="country">Contains given information about country</param>
        /// <returns></returns>
        [HttpPost("add-country")]
        [AllowAnonymous]
        public async Task AddCountry([FromBody]CountryModel country)
        {
            // Check if city already exists
            var city = await cityStorage.GetCityByName(country.Capital);
            
            if (city == null)
            {
                // City not found, add it and get Id
                await cityStorage.AddCity(new City { Name = country.Capital });

                city = await cityStorage.GetCityByName(country.Capital);
            }
            
            // Check if region already exists
            var region = await regionStorage.GetRegionByName(country.Region);

            if (region == null)
            {
                // Region not found, add it and get Id
                await regionStorage.AddRegion(new Region { Name = country.Region });

                region = await regionStorage.GetRegionByName(country.Region);
            }
            
            // Check if country with the given code already exists
            var countryExtracted = await countryStorage.GetCountryByCode(country.Code);

            if (countryExtracted == null)
            {
                // Country by code not found, add new country
                await countryStorage.AddCountry(new Country
                {
                    Name = country.Name,
                    Code = country.Code,
                    Square = country.Square,
                    Population = country.Population,
                    RegionId = region.Id,
                    CapitalId = city.Id,
                });
            }
            else
            {
                // Update existing country
                await countryStorage.UpdateCountry(countryExtracted, country, region, city);
            }
        }
    }
}