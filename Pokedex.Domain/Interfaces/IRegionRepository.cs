using Pokedex.Domain.Entities;

namespace Pokedex.Domain.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(int id);
        Task<Region> GetByNameAsync(string name);
        Task CreateAsync(Region region);
        Task UpdateAsync(Region region);
        Task DeleteAsync(int id);
    }
}
