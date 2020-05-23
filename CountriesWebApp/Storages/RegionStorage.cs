using CountriesWebApp.Storages.IStorages;
using CountriesWebApp.ViewModels;
using CountriesWebApp.Data;
using CountriesWebApp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Storages
{
    public class RegionStorage : IRegionStorage
    {
        private readonly IRegionRepository regionRepository;

        public RegionStorage(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public async Task<Region> GetRegionByName(string regionName)
        {
            return await regionRepository.GetRegionByName(regionName);
        }

        public async Task AddRegion(Region region)
        {
            await regionRepository.AddRegion(region);

            await regionRepository.SaveChangesAsync();
        }
    }
}
