using CountriesWebApp.Models.Data;
using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Data.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetRegionByName(string)"/></para>
    /// <para><see cref="AddRegion(Region)"/></para>
    /// </summary>
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Provides Dependency Injection.
        /// </summary>
        /// <param name="context">Aplication database context.</param>
        public RegionRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns region with the given name.
        /// </summary>
        /// <param name="regionName">Given name of the region.</param>
        /// <returns>Region entity.</returns>
        public async Task<Region> GetRegionByName(string regionName)
        {
            var region = from r in context.Regions
                          where r.Name == regionName
                          select new Region
                          {
                              Id = r.Id,
                              Name = r.Name,
                          };

            return region.FirstOrDefault();
        }

        /// <summary>
        /// Saves region.
        /// </summary>
        /// <param name="region">Region entity.</param>
        /// <returns></returns>
        public async Task AddRegion(Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException("Region");
            }

            await context.Regions.AddAsync(region);
            await context.SaveChangesAsync();
        }
    }
}
