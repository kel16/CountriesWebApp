using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CountriesWebApp.Models.ViewModels
{
    /// <summary>
    /// Describes country view model.
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Area of country.
        /// </summary>
        public double? Area { get; set; }

        /// <summary>
        /// Country code - string.
        /// </summary>
        [Required(ErrorMessage = "Country's code must be specified")]
        public string Code { get; set; }

        /// <summary>
        /// Name of the country.
        /// </summary>
        [Required(ErrorMessage = "Country's name must be specified")]
        public string Name { get; set; }

        /// <summary>
        /// Country population.
        /// </summary>
        [Required(ErrorMessage = "Country's population must be specified")]
        public int Population { get; set; }

        /// <summary>
        /// Name of the region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Name of the capital.
        /// </summary>
        public string Capital { get; set; }
    }

    /// <summary>
    /// Describes list of country view models.
    /// </summary>
    public class ListCountryModels
    {
        /// <summary>
        /// List of country view models.
        /// </summary>
        public List<CountryModel> Countries { get; set; }

        /// <summary>
        /// Total number of instances in the list.
        /// </summary>
        public int Total { get; set; }
    }
}
