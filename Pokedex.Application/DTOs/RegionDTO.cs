namespace Pokedex.Application.DTOs
{
    public class RegionDTO
    {
        public string Name { get; set; }
        public IEnumerable<PokemonDTO> Pokemons { get; set; }
    }
}
