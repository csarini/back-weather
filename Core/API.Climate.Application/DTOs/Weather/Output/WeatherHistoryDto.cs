using System.Text.Json.Serialization;

namespace API.Climate.Application.DTOs.Weather.Output
{
    public class WeatherHistoryDto
    {
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; } = "Argentina";
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
    }
}
