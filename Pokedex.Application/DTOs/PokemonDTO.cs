using Pokedex.Domain.Entities.Enums;
using Pokedex.Domain.Entities;

namespace Pokedex.Application.DTOs
{
    public class PokemonDTO
    {
        public string Name { get; private set; }
        public int PokedexNumber { get; private set; }
        public List<EPokemonType> Type { get; private set; }
        public string Description { get; private set; }
        public int EvolutionStage { get; private set; }
        public List<string> EvolutionLine { get; private set; }
        public bool IsStarter { get; private set; }
        public bool IsLegendary { get; private set; }
        public bool IsMythical { get; private set; }
        public bool IsUltraBeast { get; private set; }
        public bool IsMega { get; set; }
        public string UrlImage { get; private set; }
        public string RegionName { get; set; }
    }
}
