using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Handlers.Querys;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.Mappings;

namespace Pokedex.Tests.QueryTests
{
    public class GetAllPokemonsQueryRequestTest
    {
        private readonly IMapper _mapper;
        private GetAllPokemonsQueryHandler _getAllPokemonsQueryHandler;

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
            _getAllPokemonsQueryHandler = new GetAllPokemonsQueryHandler();
        }
    }
}
