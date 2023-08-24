using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class SmsCommandConfiguration : IEntityTypeConfiguration<SmsCommand>
    {
        public void Configure(EntityTypeBuilder<SmsCommand> entity)
        {
            entity.HasKey(e => e.SmsCommandId).HasName("PRIMARY");

            entity.ToTable("SmsCommand");

            entity.HasIndex(e => e.HardwareTypeId, "FK_SmsCommand_HardwareType");

            entity.Property(e => e.SmsCommandId).HasColumnType("int");
            entity.Property(e => e.Command).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Description).HasMaxLength(100).IsRequired(false);
            entity.Property(e => e.HardwareTypeId).HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);

            entity.HasOne(d => d.HardwareType).WithMany(p => p.SmsCommands)
                .HasForeignKey(d => d.HardwareTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SmsCommand_HardwareType");
        }
    }
}