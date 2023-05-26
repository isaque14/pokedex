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
    public class GetPokemonsByLegendaryQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonsByLegendaryQueryHandler _handler;
        private const int _allPokemonsLegendaryInFakeRepository = 2;

        public GetPokemonsByLegendaryQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonsByLegendaryQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return all pokemons legendary")]
        public void QueryHandler_ValidQuery_ReturnPokemonByPokedexNumber()
        {
            GenericResponse response = _handler.Handle(new GetPokemonsByLegendaryQueryRequest(), new CancellationToken()).Result;
            var pokemonsDTO = response.Object as List<PokemonDTO>;
            Assert.Equal(_allPokemonsLegendaryInFakeRepository, pokemonsDTO.Count);
        }
    }
}
