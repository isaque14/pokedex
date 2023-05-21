using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.Interfaces;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Entities.Enums;
using System.Xml.Linq;

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

        public async Task<GenericResponse> GetByIdAsync(int id)
        {
            var pokemonQuery = new GetPokemonByIdQueryRequest(id);

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetByLegendaryAsync()
        {
            var pokemonQuery = new GetPokemonsByLegendaryQueryRequest();

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetbyMegaAsync()
        {
            var pokemonQuery = new GetPokemonsByMegaQueryRequest();

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetByMythicalAsync()
        {
            var pokemonQuery = new GetPokemonsByMythicalQueryRequest();

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetByNameAsync(string name)
        {
            var pokemonQuery = new GetPokemonByNameQueryRequest(name);

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetByPokemonNumber(int pokemonNumber)
        {
            var pokemonQuery = new GetPokemonByPokedexNumberQueryRequest(pokemonNumber);

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetByRegionNameAsync(string regionName)
        {
            var pokemonQuery = new GetPokemonsByRegionNameQueryRequest(regionName);

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> GetByStarterAsync()
        {
            var pokemonQuery = new GetPokemonsByStarterQueryRequest();

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public Task<GenericResponse> GetByTypeAsync(EPokemonType type)
        {
            var pokemonQuery = new GetPokemonByPokedexNumberQueryRequest(pokemonNumber);

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
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
