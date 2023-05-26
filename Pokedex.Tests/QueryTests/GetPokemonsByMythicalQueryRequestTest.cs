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
    public class GetPokemonsByMythicalQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonsByMythicalQueryHandler _handler;
        private const int _allPokemonsMythicalInFakeRepository = 1;

        public GetPokemonsByMythicalQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonsByMythicalQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return all pokemons Mythical")]
        public void QueryHandler_ValidQuery_ReturnAllPokemosByMythical()
        {
            GenericResponse response = _handler.Handle(new GetPokemonsByMythicalQueryRequest(), new CancellationToken()).Result;
            var pokemonsDTO = response.Object as List<PokemonDTO>;
            Assert.Equal(_allPokemonsMythicalInFakeRepository, pokemonsDTO.Count);
        }
    }
}
