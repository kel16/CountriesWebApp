using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesWebApp.Models.ViewModels
{
    /// <summary>
    /// Класс, описывающий сущность города
    /// </summary>
    public class CityModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [Required(ErrorMessage = "Для города должно быть указано название")]
        public string Name { get; set; }
    }
}
