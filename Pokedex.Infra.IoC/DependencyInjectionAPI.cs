using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Application.Services.ExternalAPI;
using Pokedex.Domain.Interfaces;
using Pokedex.Infra.Data.Context;
using Pokedex.Infra.Data.Identity;
using Pokedex.Infra.Data.Repositories;

namespace Pokedex.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName))
            );

            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IGetDataPokemonInExternalAPIService, GetDataPokemonInExternalAPIService>();
            return services;
        }
    }
}