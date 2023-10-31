using System.ComponentModel.DataAnnotations;

namespace API.Climate.Domain.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
