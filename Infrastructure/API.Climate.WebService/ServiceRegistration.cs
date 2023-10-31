using API.Climate.Application.Interfaces.Repositories;
using API.Climate.WebService.Configuration;
using API.Climate.WebService.Mappings;
using Core.API.Demo.Application.Interfaces.Repositories;
using Infrastructure.API.Demo.WebService.Countries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Climate.WebService
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebServiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Http client

            AddCitiesHttpClient(services);
            AddOpenWeatherHttpClient(services);
            #endregion

            #region Http configuration

            services.Configure<CitiesApiConfig>(configuration.GetSection("CitiesApi"));
            services.Configure<OpenWeatherApiConfig>(configuration.GetSection("OpenWeatherApi"));
            services.AddAutoMapper(typeof(WebServiceMappingProfile));

            #endregion

            #region Repositories

            services.AddScoped<IWeatherRepositoryAsync, WeatherRepositoryAsync>();

            #endregion


            return services;
        }

        private static void AddCitiesHttpClient(IServiceCollection services)
        {
            services.AddHttpClient("citiesHttpClient");
        }

        private static void AddOpenWeatherHttpClient(IServiceCollection services)
        {
            services.AddHttpClient("openWeatherHttpClient");
        }
    }
}
