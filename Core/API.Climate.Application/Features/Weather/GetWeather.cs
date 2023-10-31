using API.Climate.Application.DTOs.Weather.Output;
using API.Climate.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Climate.Application.Features.Weather
{
    public class GetWeather : IRequest<WeatherDto> {

        [Required]
        [JsonPropertyName("city_id")]
        public string CityId { get; set; }

        [Required]
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }
    }
    public class GetWeatherHandler : IRequestHandler<GetWeather, WeatherDto>
    {
        private readonly IWeatherRepositoryAsync _weatherRepositoryAsync;
        private readonly IMapper _mapper;
        public GetWeatherHandler(
            IWeatherRepositoryAsync weatherRepositoryAsync,
            IWeatherRepository weatherRepository,
            IMapper mapper
            )
        {
            _weatherRepositoryAsync = weatherRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<WeatherDto> Handle(GetWeather request, CancellationToken cancellationToken)
        {
            var weather = await _weatherRepositoryAsync.GetByCityNameAsync(request.CityName);

            return  _mapper.Map<WeatherDto>(weather);
        }
    }
}
