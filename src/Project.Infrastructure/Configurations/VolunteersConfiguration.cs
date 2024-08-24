using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Models;
using Project.Domain.Models.ModelsId;
using Project.Domain.Shared;

namespace Project.Infrastructure.Configurations;

public class VolunteersConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value)
            );

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.MiddleName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TITLE_SIZE);

        builder.Property(p => p.Experience)
            .IsRequired()
            .HasMaxLength(Constants.VOLUNTEER_MAX_EXPERIENCE);

        builder.OwnsMany(v => v.Requisites, vb =>
        {
            vb.ToJson();

            vb.Property(vr => vr.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TITLE_SIZE);

            vb.Property(vr => vr.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_DESCRIPTION_SIZE);
        });

        builder.OwnsMany(v => v.Socials, vb =>
        {
            vb.ToJson();

            vb.Property(vs => vs.Title)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TITLE_SIZE);

            vb.Property(vs => vs.Link)
                .IsRequired();
        });
    }
}
