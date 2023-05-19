using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Domain.Entities;

namespace Pokedex.Application.Services.ExternalAPI
{
    public class GetDataPokemonInExternalAPIService : IGetDataPokemonInExternalAPIService
    {
        public Task<Pokemon> GetPokeInExternalAPIByNumberPokedexAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
