using System.Text.Json.Serialization;

namespace API.Climate.WebService.Weather.Dtos.Output
{
    public class CloudsDto
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }
}
