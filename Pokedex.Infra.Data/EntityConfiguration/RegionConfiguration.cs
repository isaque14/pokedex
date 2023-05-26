using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Domain.Entities;

namespace Pokedex.Infra.Data.EntityConfiguration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);

            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        }
    }
}
