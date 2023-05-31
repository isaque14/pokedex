using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;
using System.Security.Claims;

namespace Pokedex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private const int _pokedexNumberLastPokemonOrigin = 493;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        /// <summary>
        /// Obter todos os Pokémons 
        /// </summary>
        /// <returns>Coleção de Pokémons</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetAllPokemons()
        {
            var response = await _pokemonService.GetAllAsync();

            return Ok(response);
        }

        /// <summary>
        /// Obter Pokémon pelo Id
        /// </summary>
        /// <param name="id">Identificador do Pokémon</param>
        /// <returns>Dados do Pokémon</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenericResponse>> GetPokemonById(int id)
        {
            var response = await _pokemonService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter todos os Pokémons Lendários
        /// </summary>
        /// <returns>Coleção de Pokémons Lendários</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("legendary")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByLegendary()
        {
            var response = await _pokemonService.GetByLegendaryAsync();

            return Ok(response);
        }

        /// <summary>
        /// Obter todos os Pokémons Que podem Mega Evoluir
        /// </summary>
        /// <returns>Coleção de Pokémons com Megaevolução</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Mega")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByMega()
        {
            var response = await _pokemonService.GetbyMegaAsync();

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter todos os Pokémons Míticos 
        /// </summary>
        /// <returns>Coleção de Pokémons Míticos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Mythical")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByMythical()
        {
            var response = await _pokemonService.GetByMythicalAsync();

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter Pokémon pelo Nome
        /// </summary>
        /// <returns>Dados do Pokémon</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Name/{name}")]
        public async Task<ActionResult<PokemonDTO>> GetPokemonByName(string name)
        {
            var response = await _pokemonService.GetByNameAsync(name);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter Pokémon pelo seu Número na Pokedex
        /// </summary>
        /// <returns>Dados do Pokémon</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("PokedexNumber/{pokedexNumber}")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByPokedexNumber(int pokedexNumber)
        {
            var response = await _pokemonService.GetByPokemonNumber(pokedexNumber);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter Pokémons pelo nome da Região
        /// </summary>
        /// <returns>Coleção de Pokémons</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Region/{nameRegion}")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonByNameRegion(string nameRegion)
        {
            var response = await _pokemonService.GetByRegionNameAsync(nameRegion);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

        /// <summary>
        /// Obter todos os Pokémons Iniciais 
        /// </summary>
        /// <returns>Coleção de Pokémons Iniciais</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [Route("Starter")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonStarter()
        {
            var response = await _pokemonService.GetByStarterAsync();

            return Ok(response);
        }

        /// <summary>
        /// Obter Pokémons pelo tipo
        /// </summary>
        /// <returns>Coleção de Pokémons</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("Type/{type}")]
        public async Task<ActionResult<IEnumerable<PokemonDTO>>> GetPokemonStarter(string type)
        {
            var response = await _pokemonService.GetByTypeAsync(type);

            return Ok(response);
        }

        /// <summary>
        /// Cadastrar Pokémon
        /// </summary>
        /// <param name="pokemonDTO">Dados do Pokémon</param>
        /// <returns>Pokémon Criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Falha</response>
        /// <response code="401">Não Autorizado</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PokemonDTO>> CreatePokemon(PokemonDTO pokemonDTO)
        {
            var response = await _pokemonService.CreateAsync(pokemonDTO);

            return response.IsSuccessful ? StatusCode(201, response) : BadRequest(response);
        }

        /// <summary>
        /// Atualizar um Pokémon
        /// </summary>
        /// <param name="id">Identificador do Pokémon</param>
        /// <param name="pokemonDTO">Dados do Pokémon</param>
        /// <returns>Pokémon Atualizado</returns>
        /// <response code="404">Não Encontrado</response>
        /// <response code="200">Sucesso</response>
        /// <response code="403">Credencias não autorizadas</response>
        /// <response code="401">Não Autorizado</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PokemonDTO>> UpdatePokemon(int id, PokemonDTO pokemonDTO)
        {
            if (id != pokemonDTO.Id || pokemonDTO is null)
                return BadRequest(new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, Invalid Data"
                });

            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (pokemonDTO.PokedexNumber <= _pokedexNumberLastPokemonOrigin && role is not "Admin")
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de alterar este Pokémon, confira se possua uma conta Admin"
                });
            }

            var response = await _pokemonService.UpdateAsync(pokemonDTO);

            return Ok(response);
        }

        /// <summary>
        /// Deletar um Pokémon
        /// </summary>
        /// <param name="id">Identificador do Pokémon</param>
        /// <returns>Pokémon excluído</returns>
        /// <response code="404">Não Encontrado</response>
        /// <response code="200">Sucesso</response>
        /// <response code="403">Credencias não autorizadas</response>
        /// <response code="401">Não Autorizado</response>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{id}")]
        public async Task<ActionResult<PokemonDTO>> DeletePokemon(int id)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            var responsePoke = await _pokemonService.GetByIdAsync(id);

            if (responsePoke is null)
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "No Pokémon found this Id"
                });
            }
            var pokemonDTO = responsePoke.Object as PokemonDTO;
            if (pokemonDTO.PokedexNumber <= _pokedexNumberLastPokemonOrigin && role is not "Admin" )
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de deletar este Pokémon, confira se possua uma conta Admin"
                });
            }

            var response = await _pokemonService.DeleteAsync(id);

            return response.IsSuccessful ? Ok(response) : NotFound(response);
        }

    }
}
