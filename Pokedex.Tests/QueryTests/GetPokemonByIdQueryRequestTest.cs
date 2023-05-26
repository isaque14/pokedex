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
    public class GetPokemonByIdQueryRequestTest
    {
        private readonly IMapper _mapper;
        private readonly GetPokemonByIdQueryRequestHandler _handler;

        public GetPokemonByIdQueryRequestTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);

            var provider = service.BuildServiceProvider();
            _handler = new GetPokemonByIdQueryRequestHandler(new FakePokemonRepository(), _mapper);
        }

        [Fact(DisplayName = "QueryHandler Valid return pokemon by ID")]
        public void QueryHandler_ValidQuery_ReturnPokemonByID()
        {
            var id = 6;
            GenericResponse response = _handler.Handle(new GetPokemonByIdQueryRequest(id), new CancellationToken()).Result;
            var pokemonDTO = response.Object as PokemonDTO;
            Assert.Equal(id, pokemonDTO.Id);
        }
    }
}
