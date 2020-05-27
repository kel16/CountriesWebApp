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
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetCountries()"/></para>
    /// <para><see cref="GetCountryByCode(string)"/></para>
    /// <para><see cref="GetCountryByName(string)"/></para>
    /// <para><see cref="AddCountry(CountryModel)"/></para>
    /// </summary>
    public class CountryStorage : ICountryStorage
    {
        private readonly ICountryRepository countryRepository;
        private readonly ICityRepository cityRepository;
        private readonly IRegionRepository regionRepository;
        
        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="cityRepository">City repository.</param>
        /// <param name="regionRepository">Region repository.</param>
        public CountryStorage(ICountryRepository countryRepository, ICityRepository cityRepository, IRegionRepository regionRepository)
        {
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.regionRepository = regionRepository;
        }

        /// <summary>
        /// Returns full list of countries.
        /// </summary>
        /// <returns>List of country models.</returns>
        public async Task<List<CountryModel>> GetCountries()
        {
            return await countryRepository.GetCountries();
        }

        /// <summary>
        /// Returns country model with the given name.
        /// </summary>
        /// <param name="countryName">Country name.</param>
        /// <returns>Country model.</returns>
        public async Task<CountryModel> GetCountryByName(string countryName)
        {
            return await countryRepository.GetCountryByName(countryName);
        }

        /// <summary>
        /// Adds new country.
        /// </summary>
        /// <param name="countryModel">Country view model.</param>
        /// <returns></returns>
        public async Task AddCountry(CountryModel countryModel)
        {
            // Check if city already exists.
            var city = await cityRepository.GetCityByName(countryModel.Capital);

            if (city == null)
            {
                // City not found, add it and get Id.
                await cityRepository.AddCity(new City { Name = countryModel.Capital });

                city = await cityRepository.GetCityByName(countryModel.Capital);
            }

            // Check if region already exists.
            var region = await regionRepository.GetRegionByName(countryModel.Region);

            if (region == null)
            {
                // Region not found, add it and get Id.
                await regionRepository.AddRegion(new Region { Name = countryModel.Region });

                region = await regionRepository.GetRegionByName(countryModel.Region);
            }

            // Create entity for country we want to add / update.
            var countryNew = new Country
            {
                Name = countryModel.Name,
                Code = countryModel.Code,
                Area = countryModel.Area,
                Population = countryModel.Population,
                RegionId = region.Id,
                CapitalId = city.Id,
            };

            // Check if country with the provided code already exists.
            var countryExtracted = await countryRepository.GetCountryByCode(countryModel.Code);

            if (countryExtracted == null)
            {
                // Country by code not found, add new country.
                await countryRepository.AddCountry(new Country
                {
                    Name = countryModel.Name,
                    Code = countryModel.Code,
                    Area = countryModel.Area,
                    Population = countryModel.Population,
                    RegionId = region.Id,
                    CapitalId = city.Id,
                });
            }
            else
            {
                // Update existing country.
                countryExtracted.Name = countryModel.Name;
                countryExtracted.Code = countryModel.Code;
                countryExtracted.Area = countryModel.Area;
                countryExtracted.Population = countryModel.Population;
                countryExtracted.RegionId = region.Id;
                countryExtracted.CapitalId = city.Id;
                countryExtracted.Region = region;
                countryExtracted.Capital = city;

                await countryRepository.UpdateCountry(countryExtracted);
            }
        }
    }
}
