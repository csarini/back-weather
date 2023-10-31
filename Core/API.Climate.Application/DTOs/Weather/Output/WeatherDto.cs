using System.Text.Json.Serialization;

namespace API.Climate.Application.DTOs.Weather.Output
{
    public class WeatherDto
    {
        [JsonPropertyName("weather_id")]
        public int WeatherId { get; set; }
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("weather_history")]
        public List<WeatherHistoryDto> WeatherHistories { get; set; }
        public WeatherDto()
        {
            WeatherHistories = new List<WeatherHistoryDto>();
        }
    }
}
