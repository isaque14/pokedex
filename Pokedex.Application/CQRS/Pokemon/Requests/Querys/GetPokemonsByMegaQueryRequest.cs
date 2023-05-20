using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Pokemon.Requests.Querys
{
    public class GetPokemonsByMegaQueryRequest : IRequest<GenericResponse>
    {
    }
}
