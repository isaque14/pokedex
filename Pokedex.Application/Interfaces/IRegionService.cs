using FandomStarWars.Application.CQRS.BaseResponses;
using Pokedex.Application.DTOs;

namespace Pokedex.Application.Interfaces
{
    public interface IRegionService 
    {
        Task<GenericResponse> CreateRegioAsync(RegionDTO regionDTO);
        Task<GenericResponse> UpdateRegioAsync(RegionDTO regionDTO);
    }
}
