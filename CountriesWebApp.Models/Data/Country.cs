using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Models.Data
{

    /// <summary>
    /// Describes country entity.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the country.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Country code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Country area.
        /// </summary>
        public double? Area { get; set; }

        /// <summary>
        /// Country population.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Foreign key for the city.
        /// </summary>
        public int? CapitalId { get; set; }
        [ForeignKey("CapitalId")]
        public City Capital { get; set; }

        /// <summary>
        /// Foreign key for the region.
        /// </summary>
        public int? RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}
