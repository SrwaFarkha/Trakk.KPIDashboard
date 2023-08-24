using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class DriverEventConfiguration : IEntityTypeConfiguration<DriverEvent>
    {
        public void Configure(EntityTypeBuilder<DriverEvent> entity)
        {
            entity.HasKey(e => e.DriverEventId).HasName("PRIMARY");

            entity.ToTable("DriverEvent");

            entity.HasIndex(e => e.DriverId, "FK_DriverEvent_Driver");

            entity.HasIndex(e => e.DriverEventTypeId, "FK_DriverEvent_DriverEventType");

            entity.Property(e => e.DriverEventId).HasColumnType("int");
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.DriverEventTypeId).HasColumnType("int");
            entity.Property(e => e.DriverId).HasColumnType("int");
            entity.Property(e => e.EventData).HasColumnType("text").IsRequired(false);

            entity.HasOne(d => d.DriverEventType).WithMany(p => p.DriverEvents)
                .HasForeignKey(d => d.DriverEventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DriverEvent_DriverEventType");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverEvents)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DriverEvent_Driver");
        }
    }
}