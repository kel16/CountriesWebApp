using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesWebApp.Models.ViewModels
{
    /// <summary>
    /// Describes city view model.
    /// </summary>
    public class CityModel
    {
        /// <summary>
        /// Unique ID.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Name of the city.
        /// </summary>
        [Required(ErrorMessage = "Для города должно быть указано название")]
        public string Name { get; set; }
    }
}
