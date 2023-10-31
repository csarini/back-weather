using System.ComponentModel.DataAnnotations;

namespace API.Climate.Domain.Entities
{
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
        [Required]
        public double Temp { get; set; }
        [Required]
        public double FeelsLike { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
