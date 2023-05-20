using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemon.Validations.Pokemon;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Commands
{
    public class CreatePokemonCommandHandler : IRequestHandler<CreatePokemonCommandRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        private readonly ValidateCreatePokemon _validator;

        public CreatePokemonCommandHandler(IPokemonRepository pokemonRepository, IMapper mapper, ValidateCreatePokemon validator)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public Task<GenericResponse> Handle(CreatePokemonCommandRequest request, CancellationToken cancellationToken)
        {
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return Task.FromResult(new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Oops! Review the data you provided",
                    Object = request.ErrorMensage(results.Errors)
                });
            }

            var pokemon = new Domain.Entities.Pokemon(
                name: request.Name,
                pokedexNumber: request.PokedexNumber,
                type: request.Type,
                description: request.Description,
                evolutionStage: request.EvolutionStage,
                evolutionLine: request.EvolutionLine,
                isStarter: request.IsStarter,
                isLegendary: request.IsLegendary,
                isMythical: request.IsMythical,
                isUltraBeast: request.IsUltraBeast,
                isMega: request.IsMega,
                urlImage: request.UrlImage,
                regionName: request.RegionName                
                );


        }
    }
}
