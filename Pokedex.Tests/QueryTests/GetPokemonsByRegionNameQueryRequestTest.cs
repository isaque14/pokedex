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
    public class GetPokemonsByRegionNameQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonsByRegionNameQueryRequestHandler _handler;
        private const int _allpokemonsByRegionJothoInFakeRepository = 3;

        public GetPokemonsByRegionNameQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonsByRegionNameQueryRequestHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return all pokemons By Region Name")]
        public void QueryHandler_ValidQuery_ReturnAllPokemosByRegion()
        {
            var regionName = "Jotho";
            GenericResponse response = _handler.Handle(new GetPokemonsByRegionNameQueryRequest(regionName), new CancellationToken()).Result;
            var pokemonsDTO = response.Object as List<PokemonDTO>;
            Assert.Equal(_allpokemonsByRegionJothoInFakeRepository, pokemonsDTO.Count);
        }
    }
}
