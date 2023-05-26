using AutoMapper;
using Pokedex.Application.Interfaces;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.Services
{
    public class SeedDatabaseService : ISeedDatabaseService
    {
        private readonly IGetDataPokemonInExternalAPIService _externalAPIService;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        private readonly IStatusTable _statusTable;

        public SeedDatabaseService(IGetDataPokemonInExternalAPIService externalAPIService, IPokemonRepository pokemonRepository, IMapper mapper, IStatusTable statusTable)
        {
            _externalAPIService = externalAPIService;
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
            _statusTable = statusTable;
        }

        public async Task InserData()
        {
            try
            {
                var pokemonTableIsempty = _statusTable.TableIsEmpty();

                if (pokemonTableIsempty)
                {
                    var pokemonsDTO = _externalAPIService.GetAllPokemonsGen1();
                    var pokemonsEntity = _mapper.Map<IEnumerable<Pokemon>>(pokemonsDTO);

                    foreach (var pokemon in pokemonsEntity)
                    {
                        await _pokemonRepository.CreateAsync(pokemon);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
