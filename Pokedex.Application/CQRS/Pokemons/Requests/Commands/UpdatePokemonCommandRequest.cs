using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Commands
{
    public class UpdatePokemonCommandRequest : PokemonCommand, IRequest<GenericResponse>
    {
        public int Id { get; set; }
    }
}
