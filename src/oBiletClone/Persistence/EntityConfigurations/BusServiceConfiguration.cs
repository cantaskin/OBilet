using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BusServiceConfiguration : IEntityTypeConfiguration<BusService>
{
    public void Configure(EntityTypeBuilder<BusService> builder)
    {
        builder.ToTable("BusServices").HasKey(bs => bs.Id);

        builder.Property(bs => bs.Id).HasColumnName("Id").IsRequired();
        builder.Property(bs => bs.Name).HasColumnName("Name").IsRequired();
        builder.Property(bs => bs.BusId).HasColumnName("BusId").IsRequired();
        builder.Property(bs => bs.RootId).HasColumnName("RootId").IsRequired();
        builder.Property(bs => bs.StartTime).HasColumnName("StartTime");
        builder.Property(bs => bs.FinishTime).HasColumnName("FinishTime");
        builder.Property(bs => bs.BasePrice).HasColumnName("BasePrice");
        builder.Property(bs => bs.IsSellable).HasColumnName("IsSellable").IsRequired();

        builder.Property(bs => bs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bs => bs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bs => bs.DeletedDate).HasColumnName("DeletedDate");



        builder.HasOne(bs => bs.Bus)
            .WithMany(b => b.BusServices)
            .HasForeignKey(bs => bs.BusId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasQueryFilter(bs => !bs.DeletedDate.HasValue);
    }
}