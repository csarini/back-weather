using API.Climate.Domain.Entities;

namespace API.Climate.Application.Interfaces.Repositories
{
    public interface IWeatherRepository
    {
        Task<List<Weather>> GetAllByCityAsync(int cityId);
        Task AddAsync(Weather weather);
    }
}
