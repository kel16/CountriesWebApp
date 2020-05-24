using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories.IRepositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="CityRepository()"/></para>
    /// <para><see cref="AddCity()"/></para>
    /// <para><see cref="GetCityByName()"/></para>
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Saves city entity.
        /// </summary>
        /// <param name="city">City entity.</param>
        /// <returns></returns>
        Task AddCity(City country);

        /// <summary>
        /// Returns city with the given name.
        /// </summary>
        /// <param name="cityName">Given name of the city.</param>
        /// <returns></returns>
        Task<City> GetCityByName(string cityName);
    }
}
