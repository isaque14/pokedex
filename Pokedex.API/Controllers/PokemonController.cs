using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;

namespace Pokedex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetAllPokemons()
        {
            var response = await _pokemonService.GetAllAsync();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemonById(int id)
        {
            var response = await _pokemonService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("legendary")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByLegendary()
        {
            var response = await _pokemonService.GetByLegendaryAsync();

            return Ok(response);
        }

        [HttpGet]
        [Route("Mega")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByMega()
        {
            var response = await _pokemonService.GetbyMegaAsync();

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("Mythical")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByMythical()
        {
            var response = await _pokemonService.GetByMythicalAsync();

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("Name/{name}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemonByName(string name)
        {
            var response = await _pokemonService.GetByNameAsync(name);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("PokedexNumber/{pokedexNumber}")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByPokedexNumber(int pokedexNumber)
        {
            var response = await _pokemonService.GetByPokemonNumber(pokedexNumber);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("Region/{nameRegion}")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByNameRegion(string nameRegion)
        {
            var response = await _pokemonService.GetByRegionNameAsync(nameRegion);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        [HttpGet]
        [Route("Starter")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonStarter()
        {
            var response = await _pokemonService.GetByStarterAsync();

            return Ok(response);
        }

        [HttpGet]
        [Route("Type/{type}")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonStarter(string type)
        {
            var response = await _pokemonService.GetByTypeAsync(type);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonDTO>> CreatePokemon(PokemonDTO pokemonDTO)
        {
            var response = await _pokemonService.CreateAsync(pokemonDTO);

            return response.IsSuccessful ? StatusCode(201, response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<PokemonDTO>> UpdatePokemon(int id, PokemonDTO pokemonDTO)
        {
            if (id != pokemonDTO.Id || pokemonDTO is null)
                return BadRequest(new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, Invalid Data"
                });

            var response = await _pokemonService.UpdateAsync(pokemonDTO);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<PokemonDTO>> DeletePokemon(int id)
        {
            var response = await _pokemonService.DeleteAsync(id);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

    }
}
