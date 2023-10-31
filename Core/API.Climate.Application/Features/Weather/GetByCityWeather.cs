using API.Climate.Application.DTOs.City.OutPut;
using API.Climate.Application.DTOs.Weather.Output;
using API.Climate.Application.Interfaces.Repositories;
using AutoMapper;
using Core.API.Demo.Application.Interfaces.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Climate.Application.Features.Weather
{
    public class GetByCityWeather : IRequest<WeatherDto> {

        [Required]
        [JsonPropertyName("city_id")]
        public int CityId { get; set; }
        [Required]
        [JsonPropertyName("include_history")]
        public bool IncludeHistory { get; set; }
    }
    public class GetByCityWeatherHandler : IRequestHandler<GetByCityWeather, WeatherDto>
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IWeatherRepositoryAsync _weatherRepositoryAsync;
        private readonly IWeatherRepository _weatherRepository;

        private readonly IMapper _mapper;
        public GetByCityWeatherHandler(
            IWeatherRepository weatherRepository,
            IWeatherRepositoryAsync weatherRepositoryAsync,
            ICitiesRepository citiesRepository,
            IMapper mapper
            )
        {
            _weatherRepository = weatherRepository;
            _weatherRepositoryAsync = weatherRepositoryAsync;
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }
        public async Task<WeatherDto> Handle(GetByCityWeather request, CancellationToken cancellationToken)
        {
            var city = await _citiesRepository.GetByIdAsync(request.CityId);
            var weather = await _weatherRepositoryAsync.GetByCityNameAsync(city.Name);
            var weatherDto = _mapper.Map<WeatherDto>(weather);
            weatherDto.CityName = city.Name;
            weather.CityId = city.CityId;
            await _weatherRepository.AddAsync(weather);
            if(request.IncludeHistory)
            {
                var weathers = await _weatherRepository.GetAllByCityAsync(weather.CityId);
                var weathersDto = _mapper.Map<List<WeatherHistoryDto>>(weathers);
                weatherDto.WeatherHistories = weathersDto;
            }
            return  _mapper.Map<WeatherDto>(weatherDto);
        }
    }
}
