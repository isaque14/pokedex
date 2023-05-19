using Pokedex.Domain.Entities.Base;

namespace Pokedex.Domain.Entities
{
    public sealed class Region : Entity
    {
        public string Name { get; private set; }
        public ICollection<Pokemon> Pokemons { get; set; }

        public Region(string name)
        {
            Name = name;
        }

        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
