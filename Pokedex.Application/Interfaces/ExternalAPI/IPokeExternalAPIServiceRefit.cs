using Refit;

namespace Pokedex.Application.Services.ExternalAPI
{
    public interface IPokeExternalAPIServiceRefit
    {
        [Get("pokemon/{id}")]
        [Headers("User-Agent: PokedexAPI (https://github.com/isaque14/pokedex, v1)")]
        Task<ExternalPoke> GetPokemonByNumberPokedex(int pokemonNumber);
    }
}
