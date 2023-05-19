using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Domain.Entities;

namespace Pokedex.Infra.Data.EntityConfiguration
{
    public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.HasKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.UrlImage).IsRequired();
        }
    }
}
