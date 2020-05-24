using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesWebApp.Models.ViewModels
{
    /// <summary>
    /// Describes region view model.
    /// </summary>
    public class RegionModel
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name of the region.
        /// </summary>
        [Required(ErrorMessage = "Для региона должно быть указано название")]
        public string Name { get; set; }
    }
}
