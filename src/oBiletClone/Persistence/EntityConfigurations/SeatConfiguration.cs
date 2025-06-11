using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.BusId).HasColumnName("BusId").IsRequired();
        builder.Property(s => s.LocalSeatId).HasColumnName("LocalSeatId").IsRequired();
        builder.Property(s => s.LeftSeatId).HasColumnName("LeftSeatId");
        builder.Property(s => s.RightSeatId).HasColumnName("RightSeatId");
        builder.Property(s => s.TopSeatId).HasColumnName("TopSeatId");
        builder.Property(s => s.BottomSeatId).HasColumnName("BottomSeatId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}