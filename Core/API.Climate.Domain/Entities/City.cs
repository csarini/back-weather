using System.ComponentModel.DataAnnotations;

namespace API.Climate.Domain.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Weather> Weathers { get; set; }
    }
}
