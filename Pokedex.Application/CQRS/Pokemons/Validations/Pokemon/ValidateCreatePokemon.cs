using FluentValidation;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;

namespace Pokedex.Application.CQRS.Pokemon.Validations.Pokemon
{
    public class ValidateCreatePokemon : AbstractValidator<CreatePokemonCommandRequest>
    {
        public ValidateCreatePokemon()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be empty");

            RuleFor(p => p.Name)
                .MinimumLength(3)
                .WithMessage("Name cannot be less than 3 characters");

            RuleFor(p => p.PokedexNumber)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("pokemon number in pokedex cannot be empty or less than or equal to 0");

            RuleFor(p => p.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Description must be a maximum of 100 characters");

            RuleFor(p => p.UrlImage)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("pokemon image url cannot be empty");
        }
    }
}
