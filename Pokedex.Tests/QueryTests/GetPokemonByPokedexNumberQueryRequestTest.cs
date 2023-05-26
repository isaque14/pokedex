using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Handlers.Querys;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Application.Mappings;
using Pokedex.Tests.Repositories;

namespace Pokedex.Tests.QueryTests
{
    public class GetPokemonByPokedexNumberQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonByPokedexNumberQueryHandler _handler;

        public GetPokemonByPokedexNumberQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonByPokedexNumberQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return pokemon by Pokedex Number")]
        public void QueryHandler_ValidQuery_ReturnPokemonByPokedexNumber()
        {
            var pokedexNumber = 81;
            GenericResponse response = _handler.Handle(new GetPokemonByPokedexNumberQueryRequest(pokedexNumber), new CancellationToken()).Result;
            var pokemonDTO = response.Object as PokemonDTO;
            Assert.Equal(pokedexNumber, pokemonDTO.PokedexNumber);
        }
    }
}
