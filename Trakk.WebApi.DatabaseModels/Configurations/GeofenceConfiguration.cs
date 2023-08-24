using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class GeofenceConfiguration : IEntityTypeConfiguration<Geofence>
    {
        public void Configure(EntityTypeBuilder<Geofence> entity)
        {
            entity.HasKey(e => e.GeofenceId).HasName("PRIMARY");

            entity.ToTable("Geofence");

            entity.HasIndex(e => e.CustomerId, "FK_Geofence_Customer");

            entity.HasIndex(e => e.GeofenceTypeId, "FK_Geofence_GeofenceType");

            entity.HasIndex(e => e.ScheduleId, "IX_Geofence_ScheduleId");

            entity.Property(e => e.GeofenceId).HasColumnType("int");
            entity.Property(e => e.BufferRadius).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.GeofenceTypeId).HasColumnType("int");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.ScheduleId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.TimezoneId)
                .HasMaxLength(250)
                .HasDefaultValueSql("'UTC'").IsRequired(false);
            entity.Property(x => x.Geography).HasColumnName(@"Geography").HasColumnType("geography").IsRequired();

            entity.HasOne(d => d.Customer).WithMany(p => p.Geofences)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Geofence_Customer");

            entity.HasOne(d => d.GeofenceType).WithMany(p => p.Geofences)
                .HasForeignKey(d => d.GeofenceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Geofence_GeofenceType");

            entity.HasOne(d => d.Schedule).WithMany().HasForeignKey(d => d.ScheduleId);

            entity.HasMany(d => d.Contacts).WithMany(p => p.Geofences)
                .UsingEntity<Dictionary<string, object>>(
                    "GeofenceContactMap",
                    r => r.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_GeofenceContactMap_Contact"),
                    l => l.HasOne<Geofence>().WithMany()
                        .HasForeignKey("GeofenceId")
                        .HasConstraintName("FK_GeofenceContactMap_Geofence"),
                    j =>
                    {
                        j.HasKey("GeofenceId", "ContactId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("GeofenceContactMap");
                        j.HasIndex(new[] { "ContactId" }, "FK_GeofenceContactMap_Contact");
                    });

            entity.HasMany(d => d.Groups).WithMany(p => p.Geofences)
                .UsingEntity<Dictionary<string, object>>(
                    "GeofenceGroupMap",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_GeofenceGroupMap_Group"),
                    l => l.HasOne<Geofence>().WithMany()
                        .HasForeignKey("GeofenceId")
                        .HasConstraintName("FK_GeofenceGroupMap_Geofence"),
                    j =>
                    {
                        j.HasKey("GeofenceId", "GroupId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("GeofenceGroupMap");
                        j.HasIndex(new[] { "GroupId" }, "FK_GeofenceGroupMap_Group");
                    });

            entity.HasMany(d => d.Trakkers).WithMany(p => p.Geofences)
                .UsingEntity<Dictionary<string, object>>(
                    "GeofenceTrakkerMap",
                    r => r.HasOne<Trakker>().WithMany()
                        .HasForeignKey("TrakkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_GeofenceTrakkerMap_Trakker"),
                    l => l.HasOne<Geofence>().WithMany()
                        .HasForeignKey("GeofenceId")
                        .HasConstraintName("FK_GeofenceTrakkerMap_Geofence"),
                    j =>
                    {
                        j.HasKey("GeofenceId", "TrakkerId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("GeofenceTrakkerMap");
                        j.HasIndex(new[] { "TrakkerId" }, "FK_GeofenceTrakkerMap_Trakker");
                    });
        }
    }
}