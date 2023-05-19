namespace Pokedex.Application.DTOs
{
    public class RegionDTO
    {
        public string Name { get; private set; }
        public IEnumerable<PokemonDTO> Pokemons { get; set; }
    }
}
