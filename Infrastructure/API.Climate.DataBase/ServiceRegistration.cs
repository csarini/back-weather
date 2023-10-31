using API.Climate.Application.Interfaces.Repositories;
using API.Climate.DataBase.Contexts;
using API.Climate.DataBase.Repositories;
using Core.API.Demo.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Demo.DataBase
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WeatherDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICitiesRepository, CitiesRepository>();
            services.AddTransient<IWeatherRepository, WeatherRepository>();
            return services;
        }
    }
}
