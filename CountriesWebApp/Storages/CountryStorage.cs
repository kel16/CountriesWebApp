using CountriesWebApp.Storages.IStorages;
using CountriesWebApp.ViewModels;
using CountriesWebApp.Data;
using CountriesWebApp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Storages
{
    public class CountryStorage : ICountryStorage
    {
        private readonly DataContext _context;
        private readonly ICountryRepository _countryRepository;

        public CountryStorage(DataContext context, ICountryRepository countryRepository)
        {
            _context = context;
            _countryRepository = countryRepository;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var countries = await _countryRepository.GetCountries();

            return countries;
        }
    }
}
