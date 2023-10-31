using API.Climate.Application.DTOs.City.OutPut;
using AutoMapper;
using Core.API.Demo.Application.Interfaces.Repositories;
using MediatR;

namespace API.Climate.Application.Features.Cities
{
    public class GetCities : IRequest<List<CityDto>> { }
    public class GetCitiesHandler : IRequestHandler<GetCities, List<CityDto>>
    {
        private readonly ICitiesRepository _cityRepositoryAsync;
        private readonly IMapper _mapper;
        public GetCitiesHandler(
            ICitiesRepository cityRepositoryAsync,
            IMapper mapper)
        {
            _cityRepositoryAsync = cityRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<List<CityDto>> Handle(GetCities request, CancellationToken cancellationToken)
        {
            var response = await _cityRepositoryAsync.GetAllAsync();
            return _mapper.Map<List<CityDto>>(response);
        }
    }
}
