using CountriesWebApp.Models.Data;
using CountriesWebApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net;
using System.Globalization;

namespace CountriesWebApp
{
    /// <summary>
    /// Initializes database with data.
    /// </summary>
    public class DataSeeder
    {
        /// <summary>
        /// Country model requested from restcountries.eu
        /// </summary>
        private class CountryRequestModel
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

        /// <summary>
        /// Loads data from resource.
        /// </summary>
        private static List<CountryRequestModel> LoadData()
        {
            string link = "https://restcountries.eu/rest/v2/all?fields=name;region;capital;alpha2Code;area;population";

            WebRequest requestObject = WebRequest.Create(link);
            WebResponse responseObject = requestObject.GetResponse();
            StreamReader reader = new StreamReader(responseObject.GetResponseStream());
            string jsonObject = reader.ReadToEnd();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountryRequestModel>>(jsonObject);
        }

        /// <summary>
        /// Inserts into database new regions, cities and countries.
        /// </summary>
        /// <param name="context">Application database context.</param>
        public static void InitData(DataContext context)
        {
            int cityCount = 0;                                  // Region's and city's current IDs.
            Country newCountry;                                 // Instance of country that is being added.
            Region matchedRegion;                               // Instance of region that matches country.
            List<CountryRequestModel> countries = LoadData();   // Loads data from resource.

            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities ON");
            // context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Regions ON");
            foreach (CountryRequestModel country in countries)
            {
                newCountry = new Country()
                {
                    Name = country.Name,
                    Code = country.Alpha2Code,
                    Population = country.Population,
                    Area = country.FormattedArea,
                };

                if (country.Region != "")
                {
                    matchedRegion = context.Regions.Where(r => r.Name.ToUpper() == country.Region.Trim().ToUpper()).FirstOrDefault();

                    if (country.Capital != "")
                    {
                        context.Cities.Add(new City() { Id = ++cityCount, Name = country.Capital });

                        newCountry.CapitalId = cityCount;
                    }

                    if (matchedRegion == null)
                    {
                        context.Regions.Add(new Region() { Name = country.Region });
                        context.SaveChanges();
                        List<Region> regions = context.Regions.Select(r => new Region() { Id = r.Id, Name = r.Name }).ToList();
                        matchedRegion = context.Regions.Where(r => r.Name.ToUpper() == country.Region.ToUpper()).FirstOrDefault();
                    }

                    newCountry.RegionId = matchedRegion.Id;
                }

                context.Countries.Add(newCountry);
            };

            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Cities OFF");
            // context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Regions OFF");
        }
    }
}