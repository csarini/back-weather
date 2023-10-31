using API.Climate.DataBase.Contexts;
using API.Climate.Domain.Entities;
using Core.API.Demo.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Climate.DataBase.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly WeatherDbContext _weatherDbContext;

        public CitiesRepository(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        public async Task<List<City>> GetAllAsync()
        {
            var cities = await _weatherDbContext.Cities.ToListAsync();
            return cities;
        }

        public async Task<City> GetByIdAsync(int id)
        {
            var city = await _weatherDbContext
                                .Cities
                                .Where(x => x.CityId == id)
                                .FirstOrDefaultAsync();
            return city;
        }
    }
}
