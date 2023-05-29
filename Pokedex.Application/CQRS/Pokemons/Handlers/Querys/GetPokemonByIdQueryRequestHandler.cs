using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Querys
{
    public class GetPokemonByIdQueryRequestHandler : IRequestHandler<GetPokemonByIdQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonByIdQueryRequestHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPokemonByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonEntity = await _pokemonRepository.GetByIdAsync(request.Id);
                var pokemonDTO = _mapper.Map<PokemonDTO>(pokemonEntity);

                return new GenericResponse
                {
                    IsSuccessful = pokemonEntity is null ? false : true,
                    Message = pokemonEntity is null ? "No pokemon found for this id" : "Successfully obtained pokemon",
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
