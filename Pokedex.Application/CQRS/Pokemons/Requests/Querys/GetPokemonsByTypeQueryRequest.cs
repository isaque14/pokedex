using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands.Base;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Application.CQRS.Pokemons.Requests.Querys
{
    public class GetPokemonsByTypeQueryRequest : PokemonCommand, IRequest<GenericResponse>
    {
        public GetPokemonsByTypeQueryRequest(string type)
        {
            Type = new List<EPokemonType>();
            ConvertStringTypeToEnumType(type);
        }

        private void ConvertStringTypeToEnumType(string type)
        {
            switch (type.ToLower())
            {
                case "normal":
                    Type.Add(EPokemonType.Normal);
                    break;
                case "fire":
                    Type.Add(EPokemonType.Fire);
                    break;
                case "water":
                    Type.Add(EPokemonType.Water);
                    break;
                case "electric":
                    Type.Add(EPokemonType.Electric);
                    break;
                case "grass":
                    Type.Add(EPokemonType.Grass);
                    break;
                case "ice":
                    Type.Add(EPokemonType.Ice);
                    break;
                case "fighting":
                    Type.Add(EPokemonType.Fighting);
                    break;
                case "poison":
                    Type.Add(EPokemonType.Poison);
                    break;
                case "ground":
                    Type.Add(EPokemonType.Ground);
                    break;
                case "flying":
                    Type.Add(EPokemonType.Flying);
                    break;
                case "psychic":
                    Type.Add(EPokemonType.Psychic);
                    break;
                case "bug":
                    Type.Add(EPokemonType.Bug);
                    break;
                case "rock":
                    Type.Add(EPokemonType.Rock);
                    break;
                case "ghost":
                    Type.Add(EPokemonType.Ghost);
                    break;
                case "dragon":
                    Type.Add(EPokemonType.Dragon);
                    break;
                case "dark":
                    Type.Add(EPokemonType.Dark);
                    break;
                case "steel":
                    Type.Add(EPokemonType.Steel);
                    break;
                case "fairy":
                    Type.Add(EPokemonType.Fairy);
                    break;
                case "unknown":
                    Type.Add(EPokemonType.Unknown);
                    break;
                case "shadow":
                    Type.Add(EPokemonType.Shadow);
                    break;
                default:
                    Type.Add(EPokemonType.Unknown);
                    break;
            }
        }
    }
}
