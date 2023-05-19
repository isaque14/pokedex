using Pokedex.Domain.Entities;

namespace Pokedex.Application.Interfaces.ExternalAPI
{
    public interface IGetDataPokemonInExternalAPIService
    {
        public Task<Pokemon> GetPokeInExternalAPIByNumberPokedexAsync(int id);
    }
}
