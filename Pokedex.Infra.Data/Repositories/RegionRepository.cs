using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;
using Pokedex.Infra.Data.Context;

namespace Pokedex.Infra.Data.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regions
                .FindAsync(id);
        }

        public async Task<Region> GetByNameAsync(string name)
        {
            return await _context.Regions
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region region)
        {
            await Task.Run(() =>
            {
                _context.Update(region);
            });

            await _context.SaveChangesAsync();            
        }

        public async Task DeleteAsync(int id)
        {
            var region = await GetByIdAsync(id);
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
        }
    }
}
