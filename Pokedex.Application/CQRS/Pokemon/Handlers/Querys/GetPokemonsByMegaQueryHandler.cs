using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemon.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemon.Handlers.Querys
{
    public class GetPokemonsByMegaQueryHandler : IRequestHandler<GetPokemonsByMegaQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonsByMegaQueryHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPokemonsByMegaQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonEntity = await _pokemonRepository.GetbyMegaAsync();
                var pokemonDTO = _mapper.Map<IEnumerable<PokemonDTO>>(pokemonEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Successfully obtained Pokemons with Mega Evolution",
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
