using API.Climate.Application.DTOs.City.OutPut;
using API.Climate.Application.DTOs.Weather.Output;
using API.Climate.Domain.Entities;
using AutoMapper;

namespace API.Climate.Application.Mappings
{
    public class ApplicationMappingProfile: Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Weather, WeatherDto>()
               .ForMember(m => m.Temp, op => op.MapFrom(t => Math.Round(t.Temp - 273.15, 2)))
               .ForMember(m => m.FeelsLike, op => op.MapFrom(t => Math.Round(t.FeelsLike - 273.15, 2)));
            CreateMap<Weather, WeatherHistoryDto>()
               .ForMember(m => m.Temp, op => op.MapFrom(t => Math.Round(t.Temp - 273.15, 2)))
               .ForMember(m => m.FeelsLike, op => op.MapFrom(t => Math.Round(t.FeelsLike - 273.15, 2)))
               .ForMember(m => m.CityName, op => op.MapFrom(t => t.City.Name));
        }
    }
}
