using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Handlers.Commands;
using Pokedex.Application.CQRS.Pokemons.Validations;
using Pokedex.Application.CQRS.Region.Handlers.Commands;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.CQRS.Region.Validations;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Mappings;
using Pokedex.Application.Services;
using Pokedex.Tests.Repositories;

namespace Pokedex.Tests.HandlerTests
{
    public class CreateRegionCommandHandlerTest
    {
        private readonly CreateRegionCommand _validCommand = new CreateRegionCommand("Kanto");
        private readonly CreateRegionCommand _invalidCommand = new CreateRegionCommand("");
        private readonly ValidateCreateRegion _validator;
        private readonly IMapper _mapper;
        private readonly CreateRegionCommandHandler _handler;

        public CreateRegionCommandHandlerTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateCreateRegion>();
            service.AddScoped<IRegionService, RegionService>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreateRegion>();

            _handler = new CreateRegionCommandHandler(new FakeRegionRepository(), _mapper, _validator);
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void CreateRegionHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }

        [Fact(DisplayName = "Handler with valid command, create Region")]
        public void CreateRegionHandler_WithValidCommand_ResultInPokemonCreated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
