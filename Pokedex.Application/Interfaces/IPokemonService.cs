using FandomStarWars.Application.CQRS.BaseResponses;
using Pokedex.Domain.Entities.Enums;
using Pokedex.Domain.Entities;
using Pokedex.Application.DTOs;

namespace Pokedex.Application.Interfaces
{
    public interface IPokemonService
    {
        Task<GenericResponse> GetAllAsync();
        Task<GenericResponse> GetByIdAsync(int id);
        Task<GenericResponse> GetByPokemonNumber(int pokemonNumber);
        Task<GenericResponse> GetByNameAsync(string name);
        Task<GenericResponse> GetByTypeAsync(string type);
        Task<GenericResponse> GetByRegionNameAsync(string regionName);
        Task<GenericResponse> GetByStarterAsync();
        Task<GenericResponse> GetByLegendaryAsync();
        Task<GenericResponse> GetByMythicalAsync();
        Task<GenericResponse> GetbyMegaAsync();
        Task<GenericResponse> CreateAsync(PokemonDTO pokemonDTO);
        Task<GenericResponse> UpdateAsync(PokemonDTO pokemonDTO);
        Task<GenericResponse> DeleteAsync(int id);
    }
}
