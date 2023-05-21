using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.Interfaces;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PokemonService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

     
        public async Task<GenericResponse> GetAllAsync()
        {
            var pokemonQuery = new GetAllPokemonsQueryRequest();

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public Task<GenericResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByLegendaryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetbyMegaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByMythicalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByPokemonNumber(int pokemonNumber)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByRegionNameAsync(string regionName)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByStarterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByTypeAsync(EPokemonType type)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> GetByUltraBeastAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> CreateAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> UpdateAsync(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
