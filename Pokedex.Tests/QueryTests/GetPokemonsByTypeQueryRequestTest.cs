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
    public class GetPokemonsByTypeQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonsByTypeQueryRequestHandler _handler;
        private const int _allpokemonsByTypeInFakeRepository = 2;

        public GetPokemonsByTypeQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonsByTypeQueryRequestHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return pokemons by Type")]
        public void QueryHandler_ValidQuery_ReturnAllPokemosByType()
        {
            var type = "Electric";
            GenericResponse response = _handler.Handle(new GetPokemonsByTypeQueryRequest(type), new CancellationToken()).Result;
            var pokemonsDTO = response.Object as List<PokemonDTO>;
            Assert.Equal(_allpokemonsByTypeInFakeRepository, pokemonsDTO.Count);
        }
    }
}
