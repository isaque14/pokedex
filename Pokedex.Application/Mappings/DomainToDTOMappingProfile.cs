using AutoMapper;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities;

namespace Pokedex.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Pokemon, PokemonDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();

            CreateMap<Pokemon, Root>().ReverseMap();
        }
    }
}
