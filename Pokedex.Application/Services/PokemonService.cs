using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Application.CQRS.Pokemons.Requests.Querys;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;

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

        public async Task<GenericResponse> GetByTypeAsync(string type)
        {
            var pokemonQuery = new GetPokemonsByTypeQueryRequest(type);

            if (pokemonQuery is null)
                throw new Exception($"Entity could not be loaded.");

            var response = await _mediator.Send(pokemonQuery);
            return response;
        }

        public async Task<GenericResponse> CreateAsync(PokemonDTO pokemonDTO)
        {
            var createPokemonCommand = _mapper.Map<CreatePokemonCommandRequest>(pokemonDTO);
            var response = await _mediator.Send(createPokemonCommand);
            return response;
        }

        public async Task<GenericResponse> UpdateAsync(PokemonDTO pokemonDTO)
        {
            var updatePokemonCommand = _mapper.Map<UpdatePokemonCommandRequest>(pokemonDTO);
            var response = await _mediator.Send(updatePokemonCommand);
            return response;
        }

        public async Task<GenericResponse> DeleteAsync(int id)
        {
            var deletePokemonCommand = new DeletePokemonCommandRequest(id);
            var response = await _mediator.Send(deletePokemonCommand);
            return response;
        }
    }
}
