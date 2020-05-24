using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Models.Data
{
    /// <summary>
    /// Describes city entity.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the country.
        /// </summary>
        public string Name { get; set; }
    }
}
