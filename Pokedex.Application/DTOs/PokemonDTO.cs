using Pokedex.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Application.DTOs
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PokedexNumber { get; set; }
        public List<EPokemonType> Type { get; set; }
        public string Description { get; set; }
        public int EvolutionStage { get; set; }
        public List<string> EvolutionLine { get; set; }
        public bool IsStarter { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsMythical { get; set; }
        public bool IsUltraBeast { get; set; }
        public bool IsMega { get; set; }
        public string UrlImage { get; set; }
        public string RegionName { get; set; }
        public RegionDTO? RegionDTO { get; set; }

        public PokemonDTO()
        {
            
        }

        public PokemonDTO(string name, List<EPokemonType> type, string description, string urlImage, string regionName)
        {
            Name = name;
            Type = type;
            Description = description;
            UrlImage = urlImage;
            RegionName = regionName;
        }
    }
}
