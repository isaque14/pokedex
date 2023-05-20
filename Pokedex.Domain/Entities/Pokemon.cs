using Pokedex.Domain.Entities.Base;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Domain.Entities
{
    public sealed class Pokemon : Entity
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
        public Region Region { get; set; }

        public Pokemon(
            string name,
            int pokedexNumber,
            List<EPokemonType> type,
            string description,
            int evolutionStage,
            List<string> evolutionLine,
            bool isStarter,
            bool isLegendary,
            bool isMythical,
            bool isUltraBeast,
            bool isMega,
            string urlImage,
            string regionName)
        {
            Name = name;
            PokedexNumber = pokedexNumber;
            Type = type;
            Description = description;
            EvolutionStage = evolutionStage;
            EvolutionLine = evolutionLine;
            IsStarter = isStarter;
            IsLegendary = isLegendary;
            IsMythical = isMythical;
            IsUltraBeast = isUltraBeast;
            IsMega = isMega;
            UrlImage = urlImage;
            RegionName = regionName;
        }

        public Pokemon(
            int id,
            string name,
            int pokedexNumber,
            List<EPokemonType> type,
            string description,
            int evolutionStage,
            List<string> evolutionLine,
            bool isStarter,
            bool isLegendary,
            bool isMythical,
            bool isUltraBeast,
            bool isMega,
            string urlImage)
        {
            Id = id;
            Name = name;
            PokedexNumber = pokedexNumber;
            Type = type;
            Description = description;
            EvolutionStage = evolutionStage;
            EvolutionLine = evolutionLine;
            IsStarter = isStarter;
            IsLegendary = isLegendary;
            IsMythical = isMythical;
            IsUltraBeast = isUltraBeast;
            IsMega = isMega;
            UrlImage = urlImage;
        }

        public void Update(
            string name,
            int pokedexNumber,
            List<EPokemonType> type,
            string description,
            int evolutionStage,
            List<string> evolutionLine,
            bool isStarter,
            bool isLegendary,
            bool isMythical,
            bool isUltraBeast,
            bool isMega,
            string urlImage)
        {
            Name = name;
            PokedexNumber = pokedexNumber;
            Type = type;
            Description = description;
            EvolutionStage = evolutionStage;
            EvolutionLine = evolutionLine;
            IsStarter = isStarter;
            IsLegendary = isLegendary;
            IsMythical = isMythical;
            IsUltraBeast = isUltraBeast;
            IsMega = isMega;
            UrlImage = urlImage;
        }

    }
}
