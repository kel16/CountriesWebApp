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
    /// <para><see cref="GetRegionByName(string)"/></para>
    /// <para><see cref="AddRegion(Region)"/></para>
    /// </summary>
    public interface IRegionRepository
    {
        /// <summary>
        /// Returns region with the given name.
        /// </summary>
        /// <param name="regionName">Given name of the region.</param>
        /// <returns>Region entity.</returns>
        Task<Region> GetRegionByName(string regionName);

        /// <summary>
        /// Saves region.
        /// </summary>
        /// <param name="region">Region entity.</param>
        /// <returns></returns>
        Task AddRegion(Region region);
    }
}
