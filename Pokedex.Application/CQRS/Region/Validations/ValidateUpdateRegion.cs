using FluentValidation;
using Pokedex.Application.CQRS.Region.Requests.Commands;

namespace Pokedex.Application.CQRS.Region.Validations
{
    public class ValidateUpdateRegion : AbstractValidator<UpdateRegionCommand>
    {
        public ValidateUpdateRegion() 
        {
            RuleFor(r => r.Id)
               .GreaterThan(0)
               .WithMessage("Invalid Id");

            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("name cannot be empty");
        }
    }
}
