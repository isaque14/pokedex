using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Commands
{
    public class DeletePokemonCommandRequestHandler : IRequestHandler<DeletePokemonCommandRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;

        public DeletePokemonCommandRequestHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<GenericResponse> Handle(DeletePokemonCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemon = await _pokemonRepository.GetByIdAsync(request.Id);

                if (pokemon is null)
                {
                    return new GenericResponse
                    {
                        IsSuccessful = false,
                        Message = "no pokemon found for this id"
                    };
                }

                await _pokemonRepository.DeleteAsync(request.Id);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully deleted pokemon"
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
