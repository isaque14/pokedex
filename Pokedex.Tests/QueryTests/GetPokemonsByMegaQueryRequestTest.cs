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
    public class GetPokemonsByMegaQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonsByMegaQueryHandler _handler;
        private const int _allPokemonsMegaInFakeRepository = 3;

        public GetPokemonsByMegaQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonsByMegaQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return all pokemons with Mega Evolution")]
        public void QueryHandler_ValidQuery_ReturnAllPokemosByMega()
        {
            GenericResponse response = _handler.Handle(new GetPokemonsByMegaQueryRequest(), new CancellationToken()).Result;
            var pokemonsDTO = response.Object as List<PokemonDTO>;
            Assert.Equal(_allPokemonsMegaInFakeRepository, pokemonsDTO.Count);
        }
    }
}
