using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories.IRepositories
{
    public interface IRepository
    {
        /// <summary>
        /// Saves changes to DB
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
