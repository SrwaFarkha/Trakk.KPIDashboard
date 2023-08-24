using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> entity)
        {
            entity.HasKey(e => e.DriverId).HasName("PRIMARY");

            entity.ToTable("Driver");

            entity.HasIndex(e => e.AccountId, "FK_Driver_AccountId");

            entity.HasIndex(e => e.CustomerId, "FK_Driver_Customer");

            entity.Property(e => e.DriverId).HasColumnType("int");
            entity.Property(e => e.AccountId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Driver_AccountId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Driver_Customer");
        }
    }
}