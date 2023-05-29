using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Application.Mappings;
using Pokedex.Application.Services;
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


            services.AddControllers().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssembly(typeof(PokemonDTO).Assembly);
            });

            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IStatusTable, StatusTable>();


            services.AddScoped<IGetDataPokemonInExternalAPIService, GetDataPokemonInExternalAPIService>();
            services.AddScoped<ISeedDatabaseService, SeedDatabaseService>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IRegionService, RegionService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
           
            var myHandlers = AppDomain.CurrentDomain.Load("Pokedex.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}