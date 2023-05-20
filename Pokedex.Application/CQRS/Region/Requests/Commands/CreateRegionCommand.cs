using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Region.Requests.Commands
{
    public class CreateRegionCommand : RegionCommand, IRequest<GenericResponse>
    {
        public string Name { get; set; }

        public CreateRegionCommand(string name)
        {
            Name = name;
        }
    }
}
