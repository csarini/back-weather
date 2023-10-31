using System.Text.Json.Serialization;

namespace API.Climate.WebService.Weather.Dtos.Output
{
    public class CoordDto
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}
