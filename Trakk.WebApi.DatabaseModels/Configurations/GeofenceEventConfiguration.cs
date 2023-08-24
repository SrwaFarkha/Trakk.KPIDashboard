using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class GeofenceEventConfiguration : IEntityTypeConfiguration<GeofenceEvent>
    {
        public void Configure(EntityTypeBuilder<GeofenceEvent> entity)
        {
            entity.HasKey(e => e.GeofenceEventId).HasName("PRIMARY");

            entity.ToTable("GeofenceEvent");

            entity.HasIndex(e => e.GeofenceId, "FK_TriggeredGeofenceTrakkerMap_Geofence");

            entity.HasIndex(e => e.TrakkerId, "FK_TriggeredGeofenceTrakkerMap_Trakker");

            entity.Property(e => e.GeofenceEventId).HasColumnType("int");
            entity.Property(e => e.EnteredOn).HasMaxLength(6);
            entity.Property(e => e.GeofenceId).HasColumnType("int");
            entity.Property(e => e.GeofenceName).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.LeftOn).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.TrakkerId).HasColumnType("int");

            entity.HasOne(d => d.Geofence).WithMany(p => p.GeofenceEvents)
                .HasForeignKey(d => d.GeofenceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TriggeredGeofenceTrakkerMap_Geofence");

            entity.HasOne(d => d.Trakker).WithMany(p => p.GeofenceEvents)
                .HasForeignKey(d => d.TrakkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TriggeredGeofenceTrakkerMap_Trakker");
        }
    }
}