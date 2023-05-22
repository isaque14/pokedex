using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Tests.Repositories
{
    public class FakeRegionRepository : IRegionRepository
    {
        public async Task CreateAsync(Region region)
        {
            
        }

        public async Task DeleteAsync(int id)
        {
           
        }

        public Task<IEnumerable<Region>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Region region)
        {
            
        }
    }
}
