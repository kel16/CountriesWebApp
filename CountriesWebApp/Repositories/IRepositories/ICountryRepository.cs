using CountriesWebApp.Data;
using CountriesWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Repositories.IRepositories
{
    public interface ICountryRepository
    {
        Task<List<CountryModel>> GetCountries();
        //IQueryable<Country> GetAll();
    }
}
