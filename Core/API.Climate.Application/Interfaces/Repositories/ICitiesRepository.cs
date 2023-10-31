
using API.Climate.Domain.Entities;

namespace Core.API.Demo.Application.Interfaces.Repositories
{
    public interface ICitiesRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
    }
}
