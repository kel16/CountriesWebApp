using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data.Repositories.IRepositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="SaveChangesAsync()"/></para>
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves changes to DB.
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
