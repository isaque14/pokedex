using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities;

namespace Pokedex.Application.Interfaces.ExternalAPI
{
    public interface IGetDataPokemonInExternalAPIService
    {
        public Task<PokemonDTO> GetPokeInExternalAPIByNumberPokedexAsync(int id);
        public Task<List<PokemonDTO>> GetAllPokemonsGen1();
    }
}
