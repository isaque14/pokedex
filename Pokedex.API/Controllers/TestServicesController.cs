using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces.ExternalAPI;

namespace Pokedex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestServicesController : ControllerBase
    {
        private readonly IGetDataPokemonInExternalAPIService _getPokemons;

        public TestServicesController(IGetDataPokemonInExternalAPIService getPokemons)
        {
            _getPokemons = getPokemons;
        }

        [HttpGet]
        public async Task<List<PokemonDTO>> getExternal()
        {
            var poke = await _getPokemons.GetAllPokemonsGen1();
            return poke;
        }
    }
}
