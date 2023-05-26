using Microsoft.Extensions.DependencyInjection;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.CQRS.Region.Validations;

namespace Pokedex.Tests.CommandTests
{
    public class UpdateRegionCommandTest
    {
        private readonly UpdateRegionCommand _validCommand = new UpdateRegionCommand(1, "Kanto");
        private readonly UpdateRegionCommand _invalidCommand = new UpdateRegionCommand(0, "");
        private readonly ValidateUpdateRegion _validator;

        public UpdateRegionCommandTest()
        {
            var service = new ServiceCollection();
            service.AddScoped<ValidateUpdateRegion>();

            var provider = service.BuildServiceProvider();
            _validator = provider.GetService<ValidateUpdateRegion>();
        }

        [Fact(DisplayName = "Update Region With Valid State")]
        public void UpdateRegion_WithValidParameters_ResultObjectValidateState()
        {
            var result = _validator.Validate(_validCommand);
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Update Region With Invalid State")]
        public void UpdateRegion_WithInvalidParameters_ResultObjectInvalidState()
        {
            var result = _validator.Validate(_invalidCommand);
            Assert.False(result.IsValid);
        }
    }
}
