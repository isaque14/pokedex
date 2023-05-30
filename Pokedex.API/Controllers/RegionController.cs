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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PokemonDTO>> CreateRegion(string regionName)
        {
            var response = await _regionService.CreateRegioAsync(new RegionDTO { Name = regionName });

            return response.IsSuccessful ? StatusCode(201, response) : BadRequest(response);
        }

        [HttpPut]
        [Authorize]
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
