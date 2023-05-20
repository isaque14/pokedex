using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Application.CQRS.Pokemon.Requests.Commands.Base
{
    public class PokemonCommand 
    {
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
        public RegionDTO RegionDTO { get; set; }

        //public string ErrorMensage()//(List<ValidationFailure> errors)
        //{
        //    var msg = "";
        //    foreach (var erro in errors)
        //    {
        //        msg = msg + $"{erro + System.Environment.NewLine} ";
        //    }
        //    return msg;
        //}
    }
}
