using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class ArchivedUnitsCustomerConfiguration : IEntityTypeConfiguration<ArchivedUnitsCustomer>
    {
        public void Configure(EntityTypeBuilder<ArchivedUnitsCustomer> entity)
        {
            entity.HasKey(e => e.ArchivedUnitsCustomerId).HasName("PRIMARY");

            entity.ToTable("ArchivedUnitsCustomer");

            entity.HasIndex(e => e.CustomerId, "FK_ArchivedUnitsCustomer_Customer");

            entity.HasIndex(e => e.CustomerAdminId, "IX_ArchivedUnitsCustomer_CustomerAdminId_NullableUnique").IsUnique();

            entity.Property(e => e.ArchivedUnitsCustomerId).HasColumnType("int");
            entity.Property(e => e.CustomerAdminId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.CustomerId).HasColumnType("int");

            entity.HasOne(d => d.CustomerAdmin).WithMany(x => x.ArchivedUnitsCustomers)
                .HasForeignKey(d => d.CustomerAdminId)
                .HasConstraintName("FK_ArchivedUnitsCustomer_CustomerAdmin").IsRequired(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.ArchivedUnitsCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchivedUnitsCustomer_Customer");
        }
    }
}