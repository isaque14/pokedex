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
    public class GetPokemonByNameQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonByNameQueryHandler _handler;

        public GetPokemonByNameQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonByNameQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return pokemon by Name")]
        public void QueryHandler_ValidQuery_ReturnPokemonByName()
        {
            var name = "Mew";
            GenericResponse response = _handler.Handle(new GetPokemonByNameQueryRequest(name), new CancellationToken()).Result;
            var pokemonDTO = response.Object as PokemonDTO;
            Assert.Equal(name, pokemonDTO.Name);
        }
    }
}
