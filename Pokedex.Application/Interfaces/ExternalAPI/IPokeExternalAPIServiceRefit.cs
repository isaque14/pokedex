using Refit;

namespace Pokedex.Application.Services.ExternalAPI
{
    public interface IPokeExternalAPIServiceRefit
    {
        [Get("/pokemon/{pokemonNumber}")]
        [Headers("User-Agent: PokedexAPI (https://github.com/isaque14/pokedex, v1)")]
        Task<List<Root>> GetPokemonByNumberPokedex(int pokemonNumber);
    }
}
