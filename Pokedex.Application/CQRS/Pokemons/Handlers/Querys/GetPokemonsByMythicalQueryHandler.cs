using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Pokemons.Handlers.Querys
{
    public class GetPokemonsByMythicalQueryHandler : IRequestHandler<GetPokemonsByMythicalQueryRequest, GenericResponse>
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public GetPokemonsByMythicalQueryHandler(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> Handle(GetPokemonsByMythicalQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var pokemonEntity = await _pokemonRepository.GetByMythicalAsync();
                var pokemonDTO = _mapper.Map<IEnumerable<PokemonDTO>>(pokemonEntity);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Successfully obtained Mythical Pokemons",
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
