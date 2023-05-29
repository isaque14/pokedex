using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Application.CQRS.Pokemons.Validations;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Commands
{
    public class UpdatePokemonCommandHandler : IRequestHandler<UpdatePokemonCommandRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        private readonly ValidateUpdatePokemon _validator;

        public UpdatePokemonCommandHandler(IPokemonRepository pokemonRepository, IMapper mapper, ValidateUpdatePokemon validator)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GenericResponse> Handle(UpdatePokemonCommandRequest request, CancellationToken cancellationToken)
        {
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Oops! Review the data you provided",
                    Object = request.ErrorMensage(results.Errors)
                };
            }

            try
            {
                var pokemon = await _pokemonRepository.GetByIdAsync(request.Id);

                if (pokemon is null)
                {
                    return new GenericResponse
                    {
                        IsSuccessful = true,
                        Message = "Ops! no pokemon found with this id",
                        Object = request.ErrorMensage(results.Errors)
                    };
                }

                pokemon.Update(
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
                 regionId: request.RegionId
                 );

                await _pokemonRepository.UpdateAsync(pokemon);
                var pokemonDTO = _mapper.Map<PokemonDTO>(pokemon);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully updated pokemon",
                    Object = pokemonDTO
                };

            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = e.Message
                };
            } 
        }
    }
}
