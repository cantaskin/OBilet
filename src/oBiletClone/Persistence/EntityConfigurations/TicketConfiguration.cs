using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(t => t.BusServiceId).HasColumnName("BusServiceId").IsRequired();
        builder.Property(t => t.SeatId).HasColumnName("SeatId").IsRequired();
        builder.Property(t => t.Price).HasColumnName("Price").IsRequired();
        builder.Property(t => t.IsCancelled).HasColumnName("IsCancelled").IsRequired();
        builder.Property(t => t.IsOnHold).HasColumnName("IsOnHold").IsRequired();
        builder.Property(t => t.HoldUntil).HasColumnName("HoldUntil");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}