using CountriesWebApp.Data;
using CountriesWebApp.ViewModels;
using CountriesWebApp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext context;

        public RegionRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Returns region with the given name
        /// </summary>
        /// <param name="regionName">Given name of the region</param>
        /// <returns></returns>
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

        public async Task AddRegion(Region region)
        {
            await context.Regions.AddAsync(region);
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
