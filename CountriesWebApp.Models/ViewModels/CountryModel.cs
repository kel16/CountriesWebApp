using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// Country code - string.
        /// </summary>
        [Required(ErrorMessage = "Country's code must be specified")]
        public string Code { get; set; }

        /// <summary>
        /// Square of country.
        /// </summary>
        [Required(ErrorMessage = "Country's square must be specified")]
        public double Square { get; set; }

        /// <summary>
        /// Country population.
        /// </summary>
        [Required(ErrorMessage = "Country's population must be specified")]
        public int Population { get; set; }

        /// <summary>
        /// Name of the country.
        /// </summary>
        [Required(ErrorMessage = "Country's name must be specified")]
        public string Name { get; set; }

        /// <summary>
        /// Name of the region.
        /// </summary>
        [Required(ErrorMessage = "Country region's name must be specified")]
        public string Region { get; set; }

        /// <summary>
        /// Name of the capital.
        /// </summary>
        [Required(ErrorMessage = "Country capital's name must be specified")]
        public string Capital { get; set; }
    }
}
