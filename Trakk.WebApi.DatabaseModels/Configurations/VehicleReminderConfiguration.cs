using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class VehicleReminderConfiguration : IEntityTypeConfiguration<VehicleReminder>
    {
        public void Configure(EntityTypeBuilder<VehicleReminder> entity)
        {
            entity.HasKey(e => e.VehicleReminderId).HasName("PRIMARY");

            entity.ToTable("VehicleReminder");

            entity.HasIndex(e => e.VehicleReminderTypeId, "FK_VehicleReminder_Vehicle");

            entity.Property(e => e.VehicleReminderId).HasColumnType("int");
            entity.Property(e => e.OdometerBreakpoint).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.ReminderDate).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.VehicleReminderTypeId).HasColumnType("int");

            entity.HasOne(d => d.VehicleReminderType).WithMany(p => p.VehicleReminders)
                .HasForeignKey(d => d.VehicleReminderTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleReminder_Vehicle");

            entity.HasMany(d => d.Contacts).WithMany(p => p.VehicleReminders)
                .UsingEntity<Dictionary<string, object>>(
                    "VehicleReminderContactMap",
                    r => r.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_VehicleReminderContactMap_Contact"),
                    l => l.HasOne<VehicleReminder>().WithMany()
                        .HasForeignKey("VehicleReminderId")
                        .HasConstraintName("FK_VehicleReminderContactMap_VehicleReminder"),
                    j =>
                    {
                        j.HasKey("VehicleReminderId", "ContactId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("VehicleReminderContactMap");
                        j.HasIndex(new[] { "ContactId" }, "FK_VehicleReminderContactMap_Contact");
                    });
        }
    }
}