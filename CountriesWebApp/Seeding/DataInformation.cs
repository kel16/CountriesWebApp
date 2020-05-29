using CountriesWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CountriesWebApp.Seeding
{
    /// <summary>
    /// Provides data loaded from api.
    /// </summary>
    public static class DataInformation
    {
        /// <summary>
        /// Loads data from resource.
        /// </summary>
        public static List<CountryModelAPI> LoadData()
        {
            string link = "https://restcountries.eu/rest/v2/all?fields=name;region;capital;alpha2Code;area;population";
            WebRequest requestObject = WebRequest.Create(link);
            WebResponse responseObject = requestObject.GetResponse();

            StreamReader reader = new StreamReader(responseObject.GetResponseStream());
            string jsonObject = reader.ReadToEnd();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountryModelAPI>>(jsonObject);
        }
    }
}
