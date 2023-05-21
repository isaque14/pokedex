using FandomStarWars.Application.CQRS.BaseResponses;
using Pokedex.Domain.Entities.Enums;
using Pokedex.Domain.Entities;

namespace Pokedex.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<GenericResponse> GetAllAsync();
        Task<GenericResponse> GetByIdAsync(int id);
        Task<GenericResponse> GetByPokemonNumber(int pokemonNumber);
        Task<GenericResponse> GetByNameAsync(string name);
        Task<GenericResponse> GetByTypeAsync(EPokemonType type);
        Task<GenericResponse> GetByRegionNameAsync(string regionName);
        Task<GenericResponse> GetByStarterAsync();
        Task<GenericResponse> GetByLegendaryAsync();
        Task<GenericResponse> GetByMythicalAsync();
        Task<GenericResponse> GetByUltraBeastAsync();
        Task<GenericResponse> GetbyMegaAsync();
        Task<GenericResponse> CreateAsync(Pokemon pokemon);
        Task<GenericResponse> UpdateAsync(Pokemon pokemon);
        Task<GenericResponse> DeleteAsync(int id);
    }
}
