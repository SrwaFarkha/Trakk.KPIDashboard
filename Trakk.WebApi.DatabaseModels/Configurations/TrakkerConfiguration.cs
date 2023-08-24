using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class TrakkerConfiguration : IEntityTypeConfiguration<Trakker>
    {
        public void Configure(EntityTypeBuilder<Trakker> entity)
        {
            entity.HasKey(e => e.TrakkerId).HasName("PRIMARY");

            entity.ToTable("Trakker");
            entity.HasIndex(e => e.CustomerId, "FK_Trakker_Customer");
            entity.HasIndex(e => e.HardwareId, "FK_Trakker_Hardware");
            entity.HasIndex(e => e.IconId, "FK_Trakker_Icon");
            entity.HasIndex(e => e.LatestEventId, "FK_Trakker_LatestEventId");
            entity.HasIndex(e => e.LatestPositionEventId, "FK_Trakker_LatestPositionEventId");
            entity.HasIndex(e => e.ScheduleId, "IX_Trakker_ScheduleId");
            entity.Property(e => e.TrakkerId).HasColumnType("int");
            entity.Property(e => e.BatteryStatus).HasColumnType("tinyint(3) unsigned").IsRequired(false);
            entity.Property(e => e.Comment).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.CostCenter).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Region).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.BusinessArea).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.EquipmentNumber).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.HardwareId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.IconId)
                .HasDefaultValueSql("'42'")
                .HasColumnType("int");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.LastContact).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.LatestEventId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.LatestPositionEventId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.ScheduleId).HasColumnType("int").IsRequired(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Trakkers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trakker_Customer").IsRequired(false);;

            entity.HasOne(d => d.Hardware).WithMany(p => p.Trakkers)
                .HasForeignKey(d => d.HardwareId)
                .HasConstraintName("FK_Trakker_Hardware").IsRequired(false);;

            entity.HasOne(d => d.Icon).WithMany(p => p.Trakkers)
                .HasForeignKey(d => d.IconId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trakker_Icon").IsRequired(false);;

            entity.HasOne(d => d.LatestEvent).WithMany(p => p.TrakkerLatestEvents)
                .HasForeignKey(d => d.LatestEventId)
                .HasConstraintName("FK_Trakker_LatestEventId").IsRequired(false);

            entity.HasOne(d => d.LatestPositionEvent).WithMany(c => c.TrakkerLatestPositionEvents)
                .HasForeignKey(x => x.LatestPositionEventId)
                .HasConstraintName("FK_Trakker_LatestPositionEventId").IsRequired(false);

            entity.HasOne(d => d.Schedule).WithMany().HasForeignKey(d => d.ScheduleId).IsRequired(false);

            entity.HasMany(d => d.Contacts).WithMany(p => p.Trakkers)
                .UsingEntity<Dictionary<string, object>>(
                    "TrakkerContactMap",
                    r => r.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_TrakkerContactMap_Contact"),
                    l => l.HasOne<Trakker>().WithMany()
                        .HasForeignKey("TrakkerId")
                        .HasConstraintName("FK_TrakkerContactMap_Trakker"),
                    j =>
                    {
                        j.HasKey("TrakkerId", "ContactId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("TrakkerContactMap");
                        j.HasIndex(new[] { "ContactId" }, "FK_TrakkerContactMap_Contact");
                    });

            entity.HasMany(d => d.Groups).WithMany(p => p.Trakkers)
                .UsingEntity<Dictionary<string, object>>(
                    "TrakkerGroupMap",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_TrakkerGroupMap_Group"),
                    l => l.HasOne<Trakker>().WithMany()
                        .HasForeignKey("TrakkerId")
                        .HasConstraintName("FK_TrakkerGroupMap_Trakker"),
                    j =>
                    {
                        j.HasKey("TrakkerId", "GroupId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("TrakkerGroupMap");
                        j.HasIndex(new[] { "GroupId" }, "FK_TrakkerGroupMap_Group");
                    });

            entity.HasMany(d => d.Vehicles).WithMany(p => p.Trakkers)
                .UsingEntity<Dictionary<string, object>>(
                    "TrakkerVehicleMap",
                    r => r.HasOne<Vehicle>().WithMany()
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("FK_TrakkerVehicleMap_Vehicle"),
                    l => l.HasOne<Trakker>().WithMany()
                        .HasForeignKey("TrakkerId")
                        .HasConstraintName("FK_TrakkerVehicleMap_Trakker"),
                    j =>
                    {
                        j.HasKey("TrakkerId", "VehicleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("TrakkerVehicleMap");
                        j.HasIndex(new[] { "VehicleId" }, "FK_TrakkerVehicleMap_Vehicle");
                    });
            
        }
    }
}