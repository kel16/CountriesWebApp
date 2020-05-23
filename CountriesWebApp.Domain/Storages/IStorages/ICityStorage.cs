using CountriesWebApp.Models.Data;
using CountriesWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Domain.Storages.IStorages
{
    public interface ICityStorage
    {
        Task<City> GetCityByName(string cityName);

        Task AddCity(City city);
    }
}
