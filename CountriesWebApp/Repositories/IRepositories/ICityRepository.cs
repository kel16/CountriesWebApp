using CountriesWebApp.ViewModels;
using CountriesWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Repositories.IRepositories
{
    public interface ICityRepository : IRepository
    {
        Task AddCity(City country);
        Task<City> GetCityByName(string cityName);
    }
}
