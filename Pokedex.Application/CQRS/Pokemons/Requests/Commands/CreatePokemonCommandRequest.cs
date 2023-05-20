using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Commands
{
    public class CreatePokemonCommandRequest : PokemonCommand, IRequest<GenericResponse>
    {
    }
}
