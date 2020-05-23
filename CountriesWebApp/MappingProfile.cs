using CountriesWebApp.Data;
using CountriesWebApp.ViewModels;
using AutoMapper;

namespace CountriesWebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryModel>()
                .ReverseMap();

            CreateMap<Region, RegionModel>()
               .ReverseMap()
               .ForMember(r => r.Id, options => options.Ignore());

            CreateMap<City, CityModel>()
               .ReverseMap()
               .ForMember(c => c.Id, options => options.Ignore());
        }
    }
}
