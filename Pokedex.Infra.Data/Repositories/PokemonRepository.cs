using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Entities.Enums;
using Pokedex.Domain.Interfaces;
using Pokedex.Infra.Data.Context;

namespace Pokedex.Infra.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            return await _context.Pokemons
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _context.Pokemons
                .FindAsync(id);
        }

        public async Task<IEnumerable<Pokemon>> GetByLegendaryAsync()
        {
            return await _context.Pokemons
                .Where(x => x.IsLegendary == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetbyMegaAsync()
        {
            return await _context.Pokemons
                .Where(x => x.IsMega == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetByMythicalAsync()
        {
            return await _context.Pokemons
                .Where(x => x.IsMythical == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pokemon> GetByNameAsync(string name)
        {
            return await _context.Pokemons
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetByRegionNameAsync(string regionName)
        {
            return await _context.Pokemons
                .Where(x => x.Region.Name == regionName)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetByStarterAsync()
        {
            return await _context.Pokemons
                .Where(x => x.IsStarter == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetByTypeAsync(EPokemonType type)
        {
            return await _context.Pokemons
                .Where(p => p.Type.Contains(type))
                .ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetByUltraBeastAsync()
        {
            return await _context.Pokemons
                .Where(x => x.IsUltraBeast == true)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateAsync(Pokemon pokemon)
        {
            await _context.Pokemons.AddAsync(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            await Task.Run(() =>
            {
                _context.Pokemons.Update(pokemon);
            });
          
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
            var pokemon = await GetByIdAsync(id);
            _context.Pokemons.Remove(pokemon);

            await _context.SaveChangesAsync();
        }
    }
}
