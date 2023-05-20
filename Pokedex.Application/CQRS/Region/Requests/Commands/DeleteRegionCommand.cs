using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Region.Requests.Commands
{
    public class DeleteRegionCommand : RegionCommand, IRequest<GenericResponse>
    {
        public int Id { get; set; }
    }
}
