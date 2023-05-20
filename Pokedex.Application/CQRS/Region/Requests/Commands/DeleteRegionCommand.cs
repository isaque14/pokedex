using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Region.Requests.Commands
{
    public class DeleteRegionCommand : IRequest<GenericResponse>
    {
        public int Id { get; set; }
    }
}
