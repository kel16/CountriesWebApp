using CountriesWebApp.Models.ViewModels;
using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories.IRepositories
{
    public interface IRegionRepository : IRepository
    {
        Task AddRegion(Region region);
        Task<Region> GetRegionByName(string regionName); //RegionModel
    }
}
