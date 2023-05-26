using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Application.CQRS.Pokemons.Validations;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Tests.CommandTests
{
    public class UpdatePokemonCommandRequestTest
    {
        private readonly UpdatePokemonCommandRequest _validCommand = new UpdatePokemonCommandRequest()
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


        private readonly ValidateUpdatePokemon _validator;

        public UpdatePokemonCommandRequestTest()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateUpdatePokemon>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdatePokemon>();
        }


        [Fact(DisplayName = "Update Pokemon With Valid State")]
        public void UpdatePokemon_WithValidParameters_ResultObjectValidateState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Update Pokemon With Invalid State")]
        public void UpdatePokemon_WithInvalidParameters_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
