using API.Climate.Application.Interfaces.Repositories;
using API.Climate.Domain.Entities;
using API.Climate.WebService.Configuration;
using API.Climate.WebService.Weather.Dtos.Output;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.API.Demo.WebService.Countries
{
    public class WeatherRepositoryAsync : IWeatherRepositoryAsync
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherApiConfig _config;
        public WeatherRepositoryAsync(
            IMapper mapper,
            IHttpClientFactory httpClientFactory,
            IOptions<OpenWeatherApiConfig> config
            )
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient("openWeatherHttpClient");
            _config = config.Value;
        }

        public async Task<Weather> GetByCityNameAsync(string cityName)
        {
            var hosturi = new Uri(_config.ApiUri);
            var requestUri = new Uri(hosturi, _config.WeatherEndPoint.Replace("_q_", cityName));
            var response = await _httpClient.GetAsync(requestUri);
            var responseContent = await response.Content.ReadAsStringAsync();
            var weatherDto = JsonSerializer.Deserialize<RootDto>(responseContent);
            var result = _mapper.Map<Weather>(weatherDto);
            return result;
        }
    }
}
