using Pokedex.Application.DTOs;
using Pokedex.Application.Interfaces.ExternalAPI;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Application.Services.ExternalAPI
{
    public class GetDataPokemonInExternalAPIService : IGetDataPokemonInExternalAPIService
    {
        private readonly IPokeExternalAPIServiceRefit _refitService;
        private const int FirstPokeGen1 = 1;
        private const int LastPokeGen1 = 151;
        private const string UrlBaseSpritPokemon = "https://firebasestorage.googleapis.com/v0/b/pokedex-28a17.appspot.com/o/pokedex%2F";
          
        public GetDataPokemonInExternalAPIService(IPokeExternalAPIServiceRefit refitService)
        {
            _refitService = refitService;
        }

        public async Task<List<PokemonDTO>> GetAllPokemonsGen1()
        {
            var pokemonsDTO = new List<PokemonDTO>();

            for (int pokemonNumber = FirstPokeGen1; pokemonNumber <= LastPokeGen1; pokemonNumber++)
            {
                var pokemonDTO = await GetPokeInExternalAPIByNumberPokedexAsync(pokemonNumber);
                pokemonsDTO.Add(pokemonDTO);
            }

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
