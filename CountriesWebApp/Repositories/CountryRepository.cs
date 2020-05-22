using CountriesWebApp.Repositories.IRepositories;
using CountriesWebApp.ViewModels;
using CountriesWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        /*public IQueryable<Country> GetAll()
        {
            var query = from country in _context.Countries
                        select country;

            return query;
        }*/

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var countries = _context.Countries
                   .Select(c => new CountryModel {
                       Id = c.Id,
                       Name = c.Name,
                       Code = c.Code,
                       Square = c.Square,
                       Population = c.Population,
                       Region = c.Region.Name,
                       Capital = c.Capital.Name,
                       /*RegionId = c.RegionId,
                       CityId = c.CapitalId*/
                   })
                   .ToListAsync();

            return await countries;
        }
    }
}
