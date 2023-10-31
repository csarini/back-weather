using API.Climate.WebService.Weather.Dtos.Output;
using AutoMapper;

namespace API.Climate.WebService.Mappings
{
    public class WebServiceMappingProfile : Profile
    {
        public WebServiceMappingProfile()
        {
            CreateMap<RootDto, Domain.Entities.Weather>()
            .ForMember(m => m.Temp, op => op.MapFrom(t => t.Main.Temp))
            .ForMember(m => m.FeelsLike, op => op.MapFrom(t => t.Main.FeelsLike));
            //.ForMember(m => m.Name, op => op.MapFrom(t => t.Name));
        }
    }
}