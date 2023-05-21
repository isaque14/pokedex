using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonByIdQueryRequest : PokemonCommand, IRequest<GenericResponse>
    {
        public int Id { get; set; }

        public GetPokemonByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
