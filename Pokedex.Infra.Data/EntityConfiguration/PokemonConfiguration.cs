using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Entities.Enums;

namespace Pokedex.Infra.Data.EntityConfiguration
{
    public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.UrlImage).IsRequired();

            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            builder
                .Property(p => p.Type)
                .HasConversion(
                    type => string.Join(",", type),
                    str => 
                        str.Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => (EPokemonType)
                            Enum.Parse(typeof(EPokemonType), s))
                            .ToList());

            builder.Property(p => p.EvolutionLine)
                .HasConversion(
                    evolutionLine => string.Join(",", evolutionLine),
                    str => str.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList());

            builder.HasOne(e => e.Region).WithMany(e => e.Pokemons).HasForeignKey(e => e.RegionId);
        }
    }
}
