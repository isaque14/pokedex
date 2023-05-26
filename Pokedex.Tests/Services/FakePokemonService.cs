using FandomStarWars.Application.CQRS.BaseResponses;
using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces;

namespace Pokedex.Tests.Services
{
    public class FakePokemonService : IPokemonService
    {
        public Task<GenericResponse> CreateAsync(PokemonDTO pokemonDTO)
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests",
                Object = pokemonDTO
            });
        }

        public Task<GenericResponse> DeleteAsync(int id)
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests"
            });
        }

        public Task<GenericResponse> GetAllAsync()
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests"
            });
        }

        public Task<GenericResponse> GetByIdAsync(int id)
        {
            return Task.FromResult(new GenericResponse
            {
                IsSuccessful = true,
                Message = "Unitary Tests"
            });
        }

        public Task<GenericResponse> GetByLegendaryAsync()
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetbyMegaAsync()
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetByMythicalAsync()   
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetByNameAsync(string name)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });    
        }

        public Task<GenericResponse> GetByPokemonNumber(int pokemonNumber)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetByRegionNameAsync(string regionName)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetByStarterAsync()
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> GetByTypeAsync(string type)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }

        public Task<GenericResponse> UpdateAsync(PokemonDTO pokemonDTO)
        {
            return Task.FromResult(new GenericResponse { IsSuccessful = true, Message = "Unitary Tests" });
        }
    }
}
