using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonsByTypeQueryRequest : PokemonCommand, IRequest<GenericResponse>
    {
        public GetPokemonsByTypeQueryRequest(string type)
        {
            if (Enum.TryParse<EPokemonType>(type, out var pokemonType))
                Type.Add(pokemonType);
            else
                Type.Add(EPokemonType.Unknown);
        }
    }
}
