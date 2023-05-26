using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;
using Pokedex.Infra.Data.Context;

namespace Pokedex.Infra.Data.Repositories
{
    public class StatusTable : IStatusTable
    {
        private readonly DataContext _context;

        public StatusTable(DataContext context)
        {
            _context = context;
        }

        public bool TableIsEmpty()
        {
            return !_context.Set<Pokemon>().Any();
        }
    }
}
