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
    public class GetAllPokemonsQueryRequestTest
    {
        private readonly IMapper _mapper;
        private GetAllPokemonsQueryHandler _getAllPokemonsQueryHandler;
        private const int _totalPokemonsInFakeRepository = 3;

        public GetAllPokemonsQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _getAllPokemonsQueryHandler = new GetAllPokemonsQueryHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return all pokemons")]
        public void QyeryHandler_ValidQuery_ReturnAllPokemons()
        {
            GenericResponse response = _getAllPokemonsQueryHandler.Handle(new GetAllPokemonsQueryRequest(), new CancellationToken()).Result;
            var pokemons = (List<PokemonDTO>) response.Object;
            Assert.Equal(_totalPokemonsInFakeRepository, pokemons.Count());
        }
    }
}
