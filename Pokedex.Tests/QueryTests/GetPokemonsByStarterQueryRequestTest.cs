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
    public class GetPokemonsByStarterQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonsByStarterQueryHandler _handler;
        private const int _allpokemonsByStarterInFakeRepository = 3;

        public GetPokemonsByStarterQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonsByStarterQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return all pokemons Starters")]
        public void QueryHandler_ValidQuery_ReturnAllPokemosByStarter()
        {
            GenericResponse response = _handler.Handle(new GetPokemonsByStarterQueryRequest(), new CancellationToken()).Result;
            var pokemonsDTO = response.Object as List<PokemonDTO>;
            Assert.Equal(_allpokemonsByStarterInFakeRepository, pokemonsDTO.Count);
        }
    }
}
