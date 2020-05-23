using CountriesWebApp.ViewModels;
using CountriesWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Repositories.IRepositories
{
    public interface IRegionRepository : IRepository
    {
        Task AddRegion(Region region);
        Task<Region> GetRegionByName(string regionName); //RegionModel
    }
}
