using AutoMapper;
using Pokedex.Application.CQRS.Pokemons.Requests.Commands;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.DTOs;

namespace Pokedex.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile() 
        {
            CreateMap<PokemonDTO, CreatePokemonCommandRequest>().ReverseMap();
            CreateMap<PokemonDTO, UpdatePokemonCommandRequest>().ReverseMap();

            CreateMap<RegionDTO, CreateRegionCommand>().ReverseMap();
            CreateMap<RegionDTO, UpdateRegionCommand>().ReverseMap();
        }
    }
}
