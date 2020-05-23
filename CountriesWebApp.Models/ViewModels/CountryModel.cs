using CountriesWebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CountriesWebApp.Models.ViewModels
{
    /// <summary>
    /// Класс, описывающий сущность страны
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Код страны - строка
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public double Square { get; set; }

        /// <summary>
        /// Население
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Идентификатор региона страны
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название региона - строка
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Название столицы - строка
        /// </summary>
        public string Capital { get; set; }

        /*public Country GetCountry()
        {
            var country = new Country();
            country.Square = this.Square;
            country.Population = this.Population;
            country.Name = this.Name;

            if (!this.RegionId.Id.HasValue)
                country.Region = this.RegionId.GetRegion();
            else
                country.RegionId = this.RegionId.Id.Value;

            if (this.Id.HasValue)
                country.Id = this.Id.Value;

            return country;
        }

        public CountryModel()
        {
        }

        public CountryModel(Country country, Region region, City capital)
        {
            Id = country.Id;
            Square = country.Square;
            Population = country.Population;
            Name = country.Name;
            RegionId = new RegionModel() { Name = region.Name };
            CityId = new CityModel() { Name = capital.Name };
        }*/
    }
}
