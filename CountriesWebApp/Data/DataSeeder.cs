using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CountriesWebApp.Data
{
    public class DataSeeder
    {
        public static List<string> RegionsInfo = new List<string>()
        {
            "Австралия",
            "Азия",
            "Африка",
            "Европа",
            "Океания",
            "Южная Америка"
        };

        public static void InitRegions(DataContext context)
        {
            var regionList = new List<Region>();

            foreach (var type in RegionsInfo)
            {
                if (context.Regions.Any(r => r.Name.ToUpper() == type.ToUpper()))
                    continue;

                regionList.Add(new Region()
                {
                    Name = type,
                });
            }

            foreach (var type in regionList)
            {
                context.Regions.Add(type);
            }
        }
    }
}