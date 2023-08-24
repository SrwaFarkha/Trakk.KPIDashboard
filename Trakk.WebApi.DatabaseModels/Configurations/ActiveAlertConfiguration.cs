using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class ActiveAlertConfiguration : IEntityTypeConfiguration<ActiveAlert>
    {
        public void Configure(EntityTypeBuilder<ActiveAlert> entity)
        {
            entity.HasKey(e => e.ActiveAlertId).HasName("PRIMARY");

            entity.ToTable("ActiveAlert");

            entity.HasIndex(e => e.GeofenceEventId, "FK_ActiveAlert_GeofenceEvent");

            entity.HasIndex(e => e.TrakkerEventId, "UK_ActiveAlert_TrakkerEventId").IsUnique();

            entity.Property(e => e.ActiveAlertId).HasColumnType("int");
            entity.Property(e => e.GeofenceEventId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.TrakkerEventId).HasColumnType("int");

            entity.HasOne(d => d.GeofenceEvent).WithMany(p => p.ActiveAlerts)
                .HasForeignKey(d => d.GeofenceEventId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade)
                .HasConstraintName("FK_ActiveAlert_GeofenceEvent");

            entity.HasOne(d => d.TrakkerEvent).WithOne(p => p.ActiveAlert)
                .HasForeignKey<ActiveAlert>(d => d.TrakkerEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActiveAlert_TrakkerEvent");
        }
    }
}