using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Querys
{
    public class GetPokemonByNameQueryHandler : IRequestHandler<GetPokemonByNameQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonByNameQueryHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPokemonByNameQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonEntity = await _pokemonRepository.GetByNameAsync(request.Name);
                var pokemonDTO = _mapper.Map<PokemonDTO>(pokemonEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = pokemonEntity is not null ? "Successfully obtained Pokemon" : "No Pokemon found with this name",
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
