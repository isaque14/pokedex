using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Querys
{
    public class GetPokemonsByTypeQueryRequestHandler : IRequestHandler<GetPokemonsByTypeQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonsByTypeQueryRequestHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPokemonsByTypeQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonsEntity = await _pokemonRepository.GetByTypeAsync(request.Type[0]);
                var pokemonDTO = _mapper.Map<IEnumerable<PokemonDTO>>(pokemonsEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Successfully obtained pokemon",
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
