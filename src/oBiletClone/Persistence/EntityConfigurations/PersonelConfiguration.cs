using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PersonelConfiguration : IEntityTypeConfiguration<Personel>
{
    public void Configure(EntityTypeBuilder<Personel> builder)
    {
        builder.ToTable("Personels").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(p => p.NationalId).HasColumnName("NationalId").IsRequired();
        builder.Property(p => p.IsMale).HasColumnName("IsMale").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}