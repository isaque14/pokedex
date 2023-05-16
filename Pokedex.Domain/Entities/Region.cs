using Pokedex.Domain.Entities.Base;

namespace Pokedex.Domain.Entities
{
    public class Region : Entity
    {
        public string Name { get; private set; }
        public ICollection<Pokemon> Pokemons { get; set; }

        public Region(string name, ICollection<Pokemon> pokemons)
        {
            Name = name;
            Pokemons = pokemons;
        }

        public Region(int id, string name, ICollection<Pokemon> pokemons)
        {
            Id = id;
            Name = name;
            Pokemons = pokemons;
        }

        public void Update(string name, ICollection<Pokemon> pokemons)
        {
            Name = name;
            Pokemons = pokemons;
        }
    }
}
