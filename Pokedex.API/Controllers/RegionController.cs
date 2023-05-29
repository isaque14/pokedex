using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;

namespace Pokedex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost]
        public async Task<ActionResult<PokemonDTO>> CreateRegion(string regionName)
        {
            var response = await _regionService.CreateRegioAsync(new RegionDTO { Name = regionName });

            return response.IsSuccessful ? StatusCode(201, response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<PokemonDTO>> UpdateRegion(int id, RegionDTO regionDTO)
        {
            if (id != regionDTO.Id || regionDTO is null)
                return BadRequest(new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Ops, Invalid Data"
                });

            var response = await _regionService.UpdateRegioAsync(regionDTO);

            return Ok(response);
        }
    }
}
