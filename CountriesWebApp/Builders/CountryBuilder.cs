using CountriesWebApp.Storages.IStorages;
using CountriesWebApp.Repositories.IRepositories;
using CountriesWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Builders
{
    public class CountryBuilder
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryStorage _countryStorage;

        public CountryBuilder(ICountryRepository countryRepository, ICountryStorage countryStorage)
        {
            _countryRepository = countryRepository;
            _countryStorage = countryStorage;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
           return await _countryStorage.GetCountries();
        }
    }
}
