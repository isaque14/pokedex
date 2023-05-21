using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;

namespace Pokedex.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RegionService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<GenericResponse> CreateRegioAsync(RegionDTO regionDTO)
        {
            var createRegionCommand = _mapper.Map<CreateRegionCommand>(regionDTO);
            var response = await _mediator.Send(createRegionCommand);
            return response;
        }

        public async Task<GenericResponse> UpdateRegioAsync(RegionDTO regionDTO)
        {
            var updateRegionCommand = _mapper.Map<UpdateRegionCommand>(regionDTO);
            var response = await _mediator.Send(updateRegionCommand);
            return response;
        }
    }
}
