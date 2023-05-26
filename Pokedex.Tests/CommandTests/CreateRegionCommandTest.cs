using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Pokemons.Validations;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.CQRS.Region.Validations;

namespace Pokedex.Tests.CommandTests
{
    public class CreateRegionCommandTest
    {
        private readonly CreateRegionCommand _validCommand = new CreateRegionCommand("Kanto");
        private readonly CreateRegionCommand _invalidCommand = new CreateRegionCommand("");
        private readonly ValidateCreateRegion _validator;

        public CreateRegionCommandTest()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateCreateRegion>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateCreateRegion>();
        }

        [Fact(DisplayName = "Create Region With Valid State")]
        public void CreateRegion_WithValidParameters_ResultObjectValidateState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Create Region With Invalid State")]
        public void CreateRegion_WithInvalidParameters_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
