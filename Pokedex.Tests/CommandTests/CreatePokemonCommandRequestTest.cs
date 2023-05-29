using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Application.CQRS.Pokemons.Validations;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Tests.CommandTests
{
    public class CreatePokemonCommandRequestTest
    {
        private readonly CreatePokemonCommandRequest _validCommand = new CreatePokemonCommandRequest
        {
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
            RegionId = 1,
            RegionDTO = new RegionDTO { Id = 1, Name = "Kanto" }
        };

        private readonly CreatePokemonCommandRequest _invalidCommand = new CreatePokemonCommandRequest
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
            RegionId = 1,
            RegionDTO = new RegionDTO { Id = 1, Name = "Kanto" }
        };


        private readonly ValidateCreatePokemon _validator;

        public CreatePokemonCommandRequestTest()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateCreatePokemon>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreatePokemon>();
        }


        [Fact(DisplayName = "Create Pokemon With Valid State")]
        public void CreatePokemon_WithValidParameters_ResultObjectValidateState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Create Pokemon With Invalid State")]
        public void CreatePokemon_WithInvalidParameters_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
