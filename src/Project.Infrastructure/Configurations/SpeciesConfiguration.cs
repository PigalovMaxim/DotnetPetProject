using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models;
using Project.Domain.Models.ModelsId;
using Project.Domain.Shared;

namespace Project.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value)
            );

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder
            .HasMany(s => s.Breeds);
    }
}
