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
    public class CityStorage : ICityStorage
    {
        private readonly ICityRepository cityRepository;

        public CityStorage(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<City> GetCityByName(string cityName)
        {
            return await cityRepository.GetCityByName(cityName);
        }

        public async Task AddCity(City city)
        {
            await cityRepository.AddCity(new City { Name = city.Name});

            await cityRepository.SaveChangesAsync();
        }
    }
}
