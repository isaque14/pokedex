using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Region.Handlers.Commands
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, GenericResponse>
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public CreateRegionCommandHandler(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        public Task<GenericResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
