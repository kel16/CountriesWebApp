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
