using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemon.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemon.Handlers.Querys
{
    public class GetAllPokemonsQueryHandler : IRequestHandler<GetAllPokemonsQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetAllPokemonsQueryHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetAllPokemonsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonsEntity = await _pokemonRepository.GetAllAsync();
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
