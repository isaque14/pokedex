using Pokedex.Domain.Entities;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(int id);
        Task<Pokemon> GetByNameAsync(string name);
        Task<IEnumerable<Pokemon>> GetByTypeAsync(EPokemonType type);
        Task<IEnumerable<Pokemon>> GetByRegionNameAsync(string regionName);
        Task<IEnumerable<Pokemon>> GetByStarterAsync();
        Task<IEnumerable<Pokemon>> GetByLegendaryAsync();
        Task<IEnumerable<Pokemon>> GetByMythicalAsync();
        Task<IEnumerable<Pokemon>> GetByUltraBeastAsync();
        Task<IEnumerable<Pokemon>> GetbyMegaAsync();
        Task CreateAsync(Pokemon pokemon);
        Task UpdateAsync(Pokemon pokemon);
        Task DeleteAsync(int id);
    }
}
