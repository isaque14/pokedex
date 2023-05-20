using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonByNameQueryRequest : IRequest<GenericResponse>
    {
        public string Name { get; set; }

        public GetPokemonByNameQueryRequest(string name)
        {
            Name = name;
        }
    }
}
