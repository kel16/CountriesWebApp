using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Models.Data
{
    /// <summary>
    /// Describes region entity.
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the region.
        /// </summary>
        public string Name { get; set; }
    }
}
