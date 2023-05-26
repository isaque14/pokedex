using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Handlers.Commands;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Application.CQRS.Pokemons.Validations;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Mappings;
using Pokedex.Application.Services;
using Pokedex.Domain.Entities.Enums;
using Pokedex.Tests.Repositories;

namespace Pokedex.Tests.HandlerTests
{
    public class UpdatePokemonCommandRequestHandlerTest
    {
        private readonly UpdatePokemonCommandRequest _validCommand = new UpdatePokemonCommandRequest
        {
            Id = 151,
            Name = "Mew",
            Type = new List<EPokemonType>() { EPokemonType.Psychic },
            PokedexNumber = 151,
            Description = "Mythical Mew Pokemon",
            EvolutionStage = 1,
            EvolutionLine = new List<string>(),
            IsStarter = false,
            IsLegendary = false,
            IsMega = false,
            IsMythical = true,
            IsUltraBeast = false,
            UrlImage = "URL Image test",
            RegionName = "Kanto",
            RegionDTO = new RegionDTO { Id = 1, Name = "Kanto" }
        };

        private readonly UpdatePokemonCommandRequest _invalidCommand = new UpdatePokemonCommandRequest
        {
            Id = 0,
            Name = "P",
            Type = new List<EPokemonType>() { EPokemonType.Psychic },
            PokedexNumber = 0,
            Description = "Mythical Mew Pokemon",
            EvolutionStage = 1,
            EvolutionLine = new List<string>(),
            IsStarter = false,
            IsLegendary = false,
            IsMega = false,
            IsMythical = true,
            IsUltraBeast = false,
            UrlImage = "URL Image test",
            RegionName = "Kanto",
            RegionDTO = new RegionDTO { Id = 1, Name = "Kanto" }
        };

        private readonly IMapper _mapper;
        private readonly ValidateUpdatePokemon _validator;
        private readonly UpdatePokemonCommandHandler _handler;

        public UpdatePokemonCommandRequestHandlerTest()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToDTOMappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            var service = new ServiceCollection();
            service.AddSingleton(_mapper);
            service.AddScoped<ValidateUpdatePokemon>();
            service.AddScoped<IPokemonService, PokemonService>();
            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdatePokemon>();

            _handler = new UpdatePokemonCommandHandler(new FakePokemonRepository(), _mapper, _validator);
        }

        [Fact(DisplayName = "Handler with invalid command result in stop application")]
        public void UpdatePokemonHandler_WithInvalidCommand_ResultInStopApplication()
        {
            GenericResponse response = _handler.Handle(_invalidCommand, new CancellationToken()).Result;
            Assert.False(response.IsSuccessful);
        }

        [Fact(DisplayName = "Handler with valid command, Update Pokemon")]
        public void UpdatePokemonHandler_WithValidCommand_ResultInPokemonCreated()
        {
            GenericResponse response = _handler.Handle(_validCommand, new CancellationToken()).Result;
            Assert.True(response.IsSuccessful);
        }
    }
}
