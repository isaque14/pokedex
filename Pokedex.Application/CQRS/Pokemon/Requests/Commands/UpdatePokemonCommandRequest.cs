using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemon.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemon.Requests.Commands
{
    public class UpdatePokemonCommandRequest : PokemonCommand, IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public UpdatePokemonCommandRequest(int id)
        {
            Id = id;
        }
    }
}
