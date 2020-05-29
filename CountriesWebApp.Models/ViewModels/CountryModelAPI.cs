using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace CountriesWebApp.Models.ViewModels
{
    /// <summary>
    /// Country model requested from restcountries.eu
    /// </summary>
    public class CountryModelAPI
    {
        /// <summary>
        /// Name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        public string Alpha2Code { get; set; }

        /// <summary>
        /// The capital of the country.
        /// </summary>
        public string Capital { get; set; }

        /// <summary>
        /// The region of the country.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Country population.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Country area.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Converted area.
        /// </summary>
        public double? FormattedArea
        {
            get
            {
                float parsed;
                NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent;
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (!Single.TryParse(Area, style, culture, out parsed))
                {
                    return null;
                }

                return Convert.ToDouble(parsed);
            }
        }
    }
}
