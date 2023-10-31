using API.Climate.Application.DTOs.Weather.Output;
using System.Text.Json.Serialization;

namespace API.Climate.Application.DTOs.City.OutPut
{
    public class CityDto
    {
        [JsonPropertyName("id")]
        public int CityId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
        [JsonPropertyName("weathers")]
        public List<WeatherDto> Weathers { get; set; }
    }
}
