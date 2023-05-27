using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Application.Services.ExternalAPI
{
    public class GetDataPokemonInExternalAPIService : IGetDataPokemonInExternalAPIService
    {
        private readonly IPokeExternalAPIServiceRefit _refitService;
        private const int FirstPokeGen1 = 1;
        private const int LastPokeGen1 = 111;
        private const int FirstPokeGen1P2 = 113;
        private const int LastPokeGen1P2 = 151;
        private const int FirstPokeGen2 = 152;
        private const int LastPokeGen2 = 251;
        private const int FirstPokeGen3 = 252;
        private const int LastPokeGen3 = 386;
        private const int FirstPokeGen4 = 387;
        private const int LastPokeGen4 = 493;
        private const int FirstPokeGen5 = 494;
        private const int LastPokeGen5 = 649;
        private const int FirstPokeGen6 = 650;
        private const int LastPokeGen6 = 721;
        private const int FirstPokeGen7 = 722;
        private const int LastPokeGen7 = 809;
        private const int FirstPokeGen8 = 810;
        private const int LastPokeGen8 = 898;

        private const string UrlBaseSpritPokemon = "https://firebasestorage.googleapis.com/v0/b/pokedex-28a17.appspot.com/o/pokedex%2F";
          
        public GetDataPokemonInExternalAPIService(IPokeExternalAPIServiceRefit refitService)
        {
            _refitService = refitService;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen1()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen1, LastPokeGen1).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen1P2, LastPokeGen1P2).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen2()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen2, LastPokeGen2).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen2, LastPokeGen2).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen3()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen3, LastPokeGen3).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen3, LastPokeGen3).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen4()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen4, LastPokeGen4).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen4, LastPokeGen4).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen5()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen5, LastPokeGen5).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen5, LastPokeGen5).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen6()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen6, LastPokeGen6).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen6, LastPokeGen6).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen7()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen7, LastPokeGen7).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen7, LastPokeGen7).Result);

            return pokemonsDTO;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen8()
        {
            var pokemonsDTO = GetPokemonsInRange(FirstPokeGen8, LastPokeGen8).Result;

            pokemonsDTO.Concat(GetPokemonsInRange(FirstPokeGen8, LastPokeGen8).Result);

            return pokemonsDTO;
        }

        public async Task<PokemonDTO> GetPokeInExternalAPIByNumberPokedexAsync(int id)
        {
            try
            {
                var pokemonExternalAPI = await _refitService.GetPokemonByNumberPokedex(id);


                var pokemonDTO = new PokemonDTO
                {
                    Name = pokemonExternalAPI[0].name,
                    PokedexNumber = int.Parse(pokemonExternalAPI[0].number),
                    Type = ConvertPokemonTypesStringInEnumEPokemonType(pokemonExternalAPI[0].types),
                    Description = pokemonExternalAPI[0].description,
                    EvolutionStage = pokemonExternalAPI[0].family.evolutionStage,
                    EvolutionLine = pokemonExternalAPI[0].family.evolutionLine,
                    IsStarter = pokemonExternalAPI[0].starter,
                    IsLegendary = pokemonExternalAPI[0].legendary,
                    IsMythical = pokemonExternalAPI[0].mythical,
                    IsUltraBeast = pokemonExternalAPI[0].ultraBeast,
                    IsMega = pokemonExternalAPI[0].mega,
                    RegionName = GetRegionByGenerationNumber(pokemonExternalAPI[0].gen),
                    UrlImage = $"{UrlBaseSpritPokemon}{pokemonExternalAPI[0].number}.png?alt=media"                  

                };

                return pokemonDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private async Task<List<PokemonDTO>> GetPokemonsInRange(int numberPokedexInitial, int NumberPokedexFinal)
        {
            var pokemonsDTO = new List<PokemonDTO>();
            for (int pokemonNumber = numberPokedexInitial; pokemonNumber <= NumberPokedexFinal; pokemonNumber++)
            {
                var pokemonDTO = await GetPokeInExternalAPIByNumberPokedexAsync(pokemonNumber);
                pokemonsDTO.Add(pokemonDTO);
            }

            return pokemonsDTO;
        }

        private List<EPokemonType> ConvertPokemonTypesStringInEnumEPokemonType(List<string> stringTypes)
        {
            var pokemonTypes = new List<EPokemonType>();

            foreach (string typeString in stringTypes)
            {
                EPokemonType pokemonType;
                if (Enum.TryParse(typeString, out pokemonType))
                {
                    pokemonTypes.Add(pokemonType);
                }
            }

            return pokemonTypes;
        }

        private string GetRegionByGenerationNumber(int genNumber)
        {
            var region = "";

            switch (genNumber)
            {
                case 1:
                    region = "Kanto";
                    break;
                case 2:
                    region = "Johto";
                    break;
                case 3:
                    region = "Hoenn";
                    break;
                case 4:
                    region = "Sinnoh";
                    break;
                case 5:
                    region = "Unova";
                    break;
                case 6:
                    region = "Kalos";
                    break;
                case 7:
                    region = "Alola";
                    break;
                case 8:
                    region = "Galar";
                    break;
                default:
                    region = "Região inválida";
                    break;
            }

            return region;
        }
    }
}
