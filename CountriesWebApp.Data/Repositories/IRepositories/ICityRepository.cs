using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories.IRepositories
{
    public interface ICityRepository : IRepository
    {
        Task AddCity(City country);
        Task<City> GetCityByName(string cityName);
    }
}
