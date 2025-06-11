using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        builder.ToTable("Stations").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(s => s.FromTickets)
            .WithOne(t => t.FromStation)
            .HasForeignKey(t => t.FromStationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.ToTickets)
            .WithOne(t => t.ToStation)
            .HasForeignKey(t => t.ToStationId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}