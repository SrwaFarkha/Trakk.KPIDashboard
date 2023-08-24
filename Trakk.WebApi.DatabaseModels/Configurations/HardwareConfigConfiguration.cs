using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class HardwareConfigConfiguration : IEntityTypeConfiguration<HardwareConfig>
    {
        public void Configure(EntityTypeBuilder<HardwareConfig> entity)
        {
            entity.HasKey(e => e.HardwareConfigId).HasName("PRIMARY");

            entity.ToTable("HardwareConfig");

            entity.HasIndex(e => e.IconId, "FK_HardwareConfig_Icon");

            entity.Property(e => e.HardwareConfigId).HasColumnType("int");
            entity.Property(e => e.IconId).HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.SecondsStillUntilStop).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.VibrationSensitivity).HasColumnType("int").IsRequired(false);

            entity.HasOne(d => d.Icon).WithMany(p => p.HardwareConfigs)
                .HasForeignKey(d => d.IconId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HardwareConfig_Icon");
        }
    }
}