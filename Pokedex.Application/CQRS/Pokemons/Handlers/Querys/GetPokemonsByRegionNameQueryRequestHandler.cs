using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Querys
{
    public class GetPokemonsByRegionNameQueryRequestHandler : IRequestHandler<GetPokemonsByRegionNameQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonsByRegionNameQueryRequestHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPokemonsByRegionNameQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonsEntity = await _pokemonRepository.GetByRegionNameAsync(request.RegionName);
                var pokemonsDTO = _mapper.Map<IEnumerable<PokemonDTO>>(pokemonsEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Successfully obtained pokemons",
                    Object = pokemonsDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = $"Error: {e.Message}"
                };
            }
        }
    }
}
