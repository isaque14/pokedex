using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Region.Requests.Commands
{
    public class UpdateRegionCommand : RegionCommand, IRequest<GenericResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UpdateRegionCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
