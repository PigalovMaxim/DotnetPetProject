using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models;
using Project.Domain.Models.ModelsId;
using Project.Domain.Shared;

namespace Project.Infrastructure.Configurations;

public class PetsConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value)
            );

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_DESCRIPTION_SIZE);

        builder.Property(p => p.Species)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Breed)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.HealthInfo)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(Constants.PHONE_LENGTH);

        builder.Property(p => p.Weight)
            .IsRequired()
            .HasMaxLength(Constants.PET_MAX_WEIGHT);

        builder.Property(p => p.Height)
            .IsRequired()
            .HasMaxLength(Constants.PET_MAX_HEIGHT);

        builder.Property(p => p.Birthday)
            .IsRequired();

        builder.Property(p => p.IsNeutered)
            .IsRequired();

        builder.Property(p => p.IsVaccinated)
            .IsRequired();

        builder.Property(p => p.HelpStatus)
            .IsRequired();

        builder.OwnsMany(p => p.Requisites, pb =>
        {
            pb.ToJson();

            pb.Property(pr => pr.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TITLE_SIZE);

            pb.Property(pr => pr.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_DESCRIPTION_SIZE);
        });

        builder.OwnsMany(p => p.Photos, pb =>
        {
            pb.ToJson();

            pb.Property(pt => pt.Path)
                .IsRequired();
            pb.Property(pt => pt.IsMain)
                .IsRequired();
        });
    }
}
