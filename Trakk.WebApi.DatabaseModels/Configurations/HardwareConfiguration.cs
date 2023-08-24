using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class HardwareConfiguration : IEntityTypeConfiguration<Hardware>
    {
        public void Configure(EntityTypeBuilder<Hardware> entity)
        {
            entity.HasKey(e => e.HardwareId).HasName("PRIMARY");

            entity.ToTable("Hardware");

            entity.HasIndex(e => e.CustomerAdminId, "FK_Hardware_CustomerAdmin");

            entity.HasIndex(e => e.HardwareConfigId, "FK_Hardware_HardwareConfig");

            entity.HasIndex(e => e.HardwareStatusId, "FK_Hardware_HardwareStatus");

            entity.HasIndex(e => e.HardwareTypeId, "FK_Hardware_HardwareType");

            entity.HasIndex(e => e.CustomerId, "IX_Hardware_CustomerId");

            entity.HasIndex(e => e.Icc, "IX_Hardware_ICC_NullableUnique").IsUnique();

            entity.HasIndex(e => e.GlobalDeviceId, "UK_Hardware_GlobalDeviceId").IsUnique();

            entity.Property(e => e.HardwareId).HasColumnType("int");
            entity.Property(e => e.BillingType).HasColumnType("int");
            entity.Property(e => e.Comment).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.CustomerAdminId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.CustomerId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.FinancePartner).HasColumnType("int");
            entity.Property(e => e.HardwareConfigId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.HardwareStatusId)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int");
            entity.Property(e => e.HardwareTypeId).HasColumnType("int");
            entity.Property(e => e.Icc).HasColumnName("ICC").IsRequired(false);
            entity.Property(e => e.OffGridThresholdSeconds)
                .HasDefaultValueSql("'604800'")
                .HasColumnType("int");
            entity.Property(e => e.SentToCustomer).HasMaxLength(6).IsRequired(false);

            entity.HasOne(d => d.CustomerAdmin).WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.CustomerAdminId)
                .HasConstraintName("FK_Hardware_CustomerAdmin").IsRequired(false);

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.CustomerId).IsRequired(false);

            entity.HasOne(d => d.HardwareConfig).WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.HardwareConfigId)
                .HasConstraintName("FK_Hardware_HardwareConfig").IsRequired(false);

            entity.HasOne(d => d.HardwareStatus).WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.HardwareStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hardware_HardwareStatus");

            entity.HasOne(d => d.HardwareType).WithMany(p => p.Hardwares)
                .HasForeignKey(d => d.HardwareTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hardware_HardwareType");
        }
    }
}