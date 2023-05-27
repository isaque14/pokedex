using Pokedex.Application.DTOs;

namespace Pokedex.Application.Interfaces.ExternalAPI
{
    public interface IGetDataPokemonInExternalAPIService
    {
        public Task<PokemonDTO> GetPokeInExternalAPIByNumberPokedexAsync(int id);
        public Task<List<PokemonDTO>> GetAllPokemonsGen1();
        public Task<List<PokemonDTO>> GetAllPokemonsGen2();
        public Task<List<PokemonDTO>> GetAllPokemonsGen3();
        public Task<List<PokemonDTO>> GetAllPokemonsGen4();
        public Task<List<PokemonDTO>> GetAllPokemonsGen5();
        public Task<List<PokemonDTO>> GetAllPokemonsGen6();
        public Task<List<PokemonDTO>> GetAllPokemonsGen7();
        public Task<List<PokemonDTO>> GetAllPokemonsGen8();
    }
}
