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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private const int _IdLastRegionOrigin = 8;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }


        /// <summary>
        /// Cadastrar Região
        /// </summary>
        /// <param name="regionName">Nome da Região</param>
        /// <returns>Região Criada</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Falha</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PokemonDTO>> CreateRegion(string regionName)
        {
            var response = await _regionService.CreateRegioAsync(new RegionDTO { Name = regionName });

            return response.IsSuccessful ? StatusCode(201, response) : BadRequest(response);
        }

        /// <summary>
        /// Atualizar um Região
        /// </summary>
        /// <param name="id">Identificador da Região</param>
        /// <param name="movie">Dados da Região</param>
        /// <returns>Região Atualizada</returns>
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
        public async Task<ActionResult<PokemonDTO>> UpdateRegion(int id, RegionDTO regionDTO)
        {
            if (id != regionDTO.Id || regionDTO is null)
                return BadRequest(new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, Invalid Data"
                });

            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);

            if (id <= _IdLastRegionOrigin && role is not "Admin")
            {
                return StatusCode(403, new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, parece que você não tem permissão de alterar esta Região, confira se possua uma conta Admin"
                });
            }

            var response = await _regionService.UpdateRegioAsync(regionDTO);

            return Ok(response);
        }
    }
}
