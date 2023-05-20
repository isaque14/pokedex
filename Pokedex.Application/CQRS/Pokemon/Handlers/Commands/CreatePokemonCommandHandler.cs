using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemon.Requests.Commands;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemon.Handlers.Commands
{
    public class CreatePokemonCommandHandler : IRequestHandler<CreatePokemonCommandRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public CreatePokemonCommandHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public Task<GenericResponse> Handle(CreatePokemonCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
