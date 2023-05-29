using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonsByRegionNameQueryRequest : IRequest<GenericResponse>
    {
        public string RegionName { get; set; }
        public GetPokemonsByRegionNameQueryRequest(string regionName)
        {
            RegionName = regionName;
        }
    }
}
