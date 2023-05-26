using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Interfaces.ExternalAPI;

namespace Pokedex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestServicesController : ControllerBase
    {
        private readonly IGetDataPokemonInExternalAPIService _getPokemons;
        private readonly ISeedDatabaseService _seedDatabaseService;

        public TestServicesController(IGetDataPokemonInExternalAPIService getPokemons, ISeedDatabaseService seedDatabaseService)
        {
            _getPokemons = getPokemons;
            _seedDatabaseService = seedDatabaseService;
        }

        [HttpGet]
        public async Task<List<PokemonDTO>> getExternal()
        {
            var poke = new List<PokemonDTO>(); //await _getPokemons.GetAllPokemonsGen1();

            await _seedDatabaseService.InserData();

            return poke;
        }
    }
}
