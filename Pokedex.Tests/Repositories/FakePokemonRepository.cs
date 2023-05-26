using Pokedex.Domain.Entities;
using Pokedex.Domain.Entities.Enums;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Tests.Repositories
{
    public class FakePokemonRepository : IPokemonRepository
    {
        public async Task CreateAsync(Pokemon pokemon)
        {
            
        }

        public async Task DeleteAsync(int id)
        {
            
        }

        public Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            var pokemonMock = new List<Pokemon>();


            pokemonMock.Add(new Pokemon(
                "Pikachu", 
                16, 
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2, 
                new List<string>() { "pichu", "pikachu", "raichu" }, 
                false, 
                false, 
                false, 
                false, 
                false, 
                "URL string here", 
                "kanto"));

            pokemonMock.Add(new Pokemon(
                "Pichu",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                false,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Raichu",
                81,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                false,
                "URL string here",
                "kanto"));

            return Task.FromResult(pokemonMock as IEnumerable<Pokemon>);
        }

        public Task<Pokemon> GetByIdAsync(int id)
        {
            
            var pokemonMock = new Pokemon(
                6,
                "Pikachu",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                false,
                "URL string here",
                "kanto");

            return Task.FromResult(pokemonMock);
        }

        public Task<IEnumerable<Pokemon>> GetByLegendaryAsync()
        {
            var pokemonsMock = new List<Pokemon>();

            pokemonsMock.Add( new Pokemon(
                6,
                "Lugia",
                87,
                new List<EPokemonType>() { EPokemonType.Flying, EPokemonType.Psychic },
                "Test Description",
                2,
                new List<string>(),
                false,
                true,
                false,
                false,
                false,
                "URL string here",
                "Jotho"));

            pokemonsMock.Add(new Pokemon(
                6,
                "MewTwo",
                150,
                new List<EPokemonType>() { EPokemonType.Psychic },
                "Test Description",
                2,
                new List<string>(),
                false,
                true,
                false,
                false,
                false,
                "URL string here",
                "Kanto"));

            return Task.FromResult(pokemonsMock as IEnumerable<Pokemon>);
        }

        public Task<IEnumerable<Pokemon>> GetbyMegaAsync()
        {
            var pokemonMock = new List<Pokemon>();

            pokemonMock.Add(new Pokemon(
                "Lucario",
                16,
                new List<EPokemonType>() { EPokemonType.Fighting },
                "Test Description",
                2,
                new List<string>() { "Riolu", "Lucario" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Pinser",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Raichu",
                81,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "kanto"));

            return Task.FromResult(pokemonMock as IEnumerable<Pokemon>);
        }

        public Task<IEnumerable<Pokemon>> GetByMythicalAsync()
        {
            var pokemonsMock = new List<Pokemon>();

            pokemonsMock.Add( new Pokemon(
                "Mew",
                81,
                new List<EPokemonType>() { EPokemonType.Psychic },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                true,
                false,
                false,
                "URL string here",
                "kanto"));

            return Task.FromResult(pokemonsMock as IEnumerable<Pokemon>);
        }

        public Task<Pokemon> GetByNameAsync(string name)
        {
            var pokemonMock = new Pokemon(
                "Mew",
                81,
                new List<EPokemonType>() { EPokemonType.Psychic },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                true,
                false,
                false,
                "URL string here",
                "kanto");

            return Task.FromResult(pokemonMock as Pokemon);
        }

        public Task<Pokemon> GetByPokemonNumber(int pokemonNumber)
        {
            var pokemonMock = new Pokemon(
                "Mew",
                81,
                new List<EPokemonType>() { EPokemonType.Psychic },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                true,
                false,
                false,
                "URL string here",
                "kanto");

            return Task.FromResult(pokemonMock as Pokemon);
        }

        public Task<IEnumerable<Pokemon>> GetByRegionNameAsync(string regionName)
        {
            var pokemonMock = new List<Pokemon>();

            pokemonMock.Add(new Pokemon(
                "Lucario",
                16,
                new List<EPokemonType>() { EPokemonType.Fighting },
                "Test Description",
                2,
                new List<string>() { "Riolu", "Lucario" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Pinser",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Raichu",
                81,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            return Task.FromResult(pokemonMock as IEnumerable<Pokemon>);
        }

        public Task<IEnumerable<Pokemon>> GetByStarterAsync()
        {
            var pokemonMock = new List<Pokemon>();

            pokemonMock.Add(new Pokemon(
                "Lucario",
                16,
                new List<EPokemonType>() { EPokemonType.Fighting },
                "Test Description",
                2,
                new List<string>() { "Riolu", "Lucario" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Pinser",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Raichu",
                81,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "kanto"));

            return Task.FromResult(pokemonMock as IEnumerable<Pokemon>);
        }

        public Task<IEnumerable<Pokemon>> GetByTypeAsync(EPokemonType type)
        {
            var pokemonMock = new List<Pokemon>();

            pokemonMock.Add(new Pokemon(
                "Pinser",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Raichu",
                81,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "kanto"));

            return Task.FromResult(pokemonMock as IEnumerable<Pokemon>);
        }

        public Task<IEnumerable<Pokemon>> GetByUltraBeastAsync()
        {
            var pokemonMock = new List<Pokemon>();

            pokemonMock.Add(new Pokemon(
                "Lucario",
                16,
                new List<EPokemonType>() { EPokemonType.Fighting },
                "Test Description",
                2,
                new List<string>() { "Riolu", "Lucario" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Pinser",
                87,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>(),
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "Jotho"));

            pokemonMock.Add(new Pokemon(
                "Raichu",
                81,
                new List<EPokemonType>() { EPokemonType.Electric },
                "Test Description",
                2,
                new List<string>() { "pichu", "pikachu", "raichu" },
                false,
                false,
                false,
                false,
                true,
                "URL string here",
                "kanto"));

            return Task.FromResult(pokemonMock as IEnumerable<Pokemon>);
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {

        }
    }
}
