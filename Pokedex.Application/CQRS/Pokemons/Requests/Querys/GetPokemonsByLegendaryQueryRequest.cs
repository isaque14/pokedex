using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonsByLegendaryQueryRequest : IRequest<GenericResponse>
    {
    }
}
