using API.Climate.Application.DTOs.Weather.Output;
using System.Text.Json.Serialization;

namespace API.Climate.WebService.Weather.Dtos.Output
{
    public class RootDto
    {
        [JsonPropertyName("coord")]
        public CoordDto Coord { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDto> Weather { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public MainDto Main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public WindDto Wind { get; set; }

        [JsonPropertyName("clouds")]
        public CloudsDto Clouds { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("sys")]
        public SysDto Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }
}
