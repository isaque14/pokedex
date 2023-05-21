using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonsByRegionNameQueryRequest : PokemonCommand, IRequest<GenericResponse>
    {
        public GetPokemonsByRegionNameQueryRequest(string regionName)
        {
            RegionName = regionName;
        }
    }
}
