using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesWebApp.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Square { get; set; }
        public int Population { get; set; }

        public int CapitalId { get; set; }
        public virtual City Capital { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
