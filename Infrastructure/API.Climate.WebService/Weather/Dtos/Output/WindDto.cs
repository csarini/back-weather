using System.Text.Json.Serialization;

namespace API.Climate.Application.DTOs.Weather.Output
{
    public class WindDto
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }
    }
}
