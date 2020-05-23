using CountriesWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesWebApp.ViewModels
{
    /// <summary>
    /// Класс, описывающий сущность региона
    /// </summary>
    public class RegionModel
    {
        public int? Id { get; set; }

        /// <summary>
        /// Название региона
        /// </summary>
        [Required(ErrorMessage = "Для региона должно быть указано название")]
        public string Name { get; set; }

        /*public Region GetRegion()
        {
            return new Region()
            {
                Name = this.Name,
            };
        }

        public RegionModel()
        {
        }*/
    }
}
