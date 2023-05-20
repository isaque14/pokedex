using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Region.Requests.Commands
{
    public class UpdateRegionCommand : IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public UpdateRegionCommand(int id)
        {
            Id = id;
        }
    }
}
