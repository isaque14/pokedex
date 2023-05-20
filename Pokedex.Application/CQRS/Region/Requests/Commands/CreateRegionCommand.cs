using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Region.Requests.Commands
{
    public class CreateRegionCommand : IRequest<GenericResponse>
    {
        public string Name { get; set; }

        public CreateRegionCommand(string name)
        {
            Name = name;
        }
    }
}
