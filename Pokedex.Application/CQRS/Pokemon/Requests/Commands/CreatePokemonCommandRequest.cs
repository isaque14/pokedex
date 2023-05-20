using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemon.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemon.Requests.Commands
{
    public class CreatePokemonCommandRequest : PokemonCommand, IRequest<GenericResponse>
    {
    }
}
