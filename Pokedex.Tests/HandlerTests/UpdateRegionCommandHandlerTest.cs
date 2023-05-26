using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Region.Handlers.Commands;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.CQRS.Region.Validations;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Mappings;
using Pokedex.Application.Services;
using Pokedex.Tests.Repositories;

namespace Pokedex.Tests.HandlerTests
{
    public class UpdateRegionCommandHandlerTest
    {
        private readonly UpdateRegionCommand _validCommand = new UpdateRegionCommand(1, "Kanto");
        private readonly UpdateRegionCommand _invalidCommand = new UpdateRegionCommand(-1, "");
        private readonly ValidateUpdateRegion _validator;
        private readonly IMapper _mapper;
        private readonly UpdateRegionCommandHandler _handler;

        public UpdateRegionCommandHandlerTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateUpdateRegion>();
            service.AddScoped<IRegionService, RegionService>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdateRegion>();

            _handler = new UpdateRegionCommandHandler(new FakeRegionRepository(), _mapper, _validator);
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void UpdateRegionHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }

        [Fact(DisplayName = "Handler with valid command, update Region")]
        public void UpdateRegionHandler_WithValidCommand_ResultInRegionUpdated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
