using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;
public class BusServiceStationConfiguration : IEntityTypeConfiguration<BusServiceStation>
{
    public void Configure(EntityTypeBuilder<BusServiceStation> builder)
    {
        builder.ToTable("BusServiceStations").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.BusServiceRootId).HasColumnName("BusServiceRootId").IsRequired();
        builder.Property(b => b.BusServiceId).HasColumnName("BusServiceId").IsRequired();
        builder.Property(b => b.Order).HasColumnName("Order").IsRequired();
        builder.Property(b => b.StationId).HasColumnName("StationId").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
