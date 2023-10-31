using API.Climate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Climate.DataBase.Contexts
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }

        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }
    }
}
