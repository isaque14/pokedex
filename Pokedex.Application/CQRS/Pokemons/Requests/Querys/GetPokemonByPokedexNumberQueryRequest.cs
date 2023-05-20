using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonByPokedexNumberQueryRequest : IRequest<GenericResponse>
    {
        public int PokemonNumber { get; set; }

        public GetPokemonByPokedexNumberQueryRequest(int pokemonNumber)
        {
            PokemonNumber = pokemonNumber;
        }
    }
}
