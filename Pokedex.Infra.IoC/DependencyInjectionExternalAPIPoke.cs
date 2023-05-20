using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.Services.ExternalAPI;
using Refit;

namespace Pokedex.Infra.IoC
{
    public static class DependencyInjectionExternalAPIPoke
    {
        public static IServiceCollection AddInfrastructureExternalApiPoke(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IPokeExternalAPIServiceRefit>()
                .ConfigureHttpClient(config => config.BaseAddress = new Uri("https://pokeapi.glitch.me/v1"));

            return services;
        }   
    }
}
