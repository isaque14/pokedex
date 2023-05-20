using FluentValidation;
using Pokedex.Application.CQRS.Region.Requests.Commands;

namespace Pokedex.Application.CQRS.Region.Validations
{
    public class ValidateCreateRegion : AbstractValidator<CreateRegionCommand>
    {
        public ValidateCreateRegion() 
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("name cannot be empty");
        }
    }
}
