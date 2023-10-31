using API.Climate.Application.Interfaces.Repositories;
using API.Climate.DataBase.Contexts;
using API.Climate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Climate.DataBase.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _weatherDbContext;

        public WeatherRepository(WeatherDbContext weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

        public async Task<List<Weather>> GetAllByCityAsync(int cityId)
        {
            var weathers = await _weatherDbContext
                                    .Weathers
                                    .Where(x => x.CityId == cityId).
                                    ToListAsync();
            return weathers;
        }

        public async Task AddAsync(Weather weather)
        {
            await _weatherDbContext.AddAsync(weather);
            _weatherDbContext.SaveChanges();
        }
    }
}
