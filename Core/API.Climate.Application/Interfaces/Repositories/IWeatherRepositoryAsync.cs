using API.Climate.Domain.Entities;

namespace API.Climate.Application.Interfaces.Repositories
{
    public interface IWeatherRepositoryAsync
    {
        Task<Weather> GetByCityNameAsync(string cityName);
    }
}
