using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

// namespace Trakk.WebApi.DatabaseModels.Configurations
// {
//     public class GeofenceScheduleConfiguration : IEntityTypeConfiguration<GeofenceSchedule>
//     {
//         public void Configure(EntityTypeBuilder<GeofenceSchedule> entity)
//         {
//             entity.HasKey(e => e.GeofenceScheduleId).HasName("PRIMARY");
//
//             entity.ToTable("GeofenceSchedule");
//
//             entity.HasIndex(e => e.GeofenceId, "FK_GeofenceSchedule_Geofence");
//
//             entity.Property(e => e.GeofenceScheduleId).HasColumnType("int");
//             entity.Property(e => e.GeofenceId).HasColumnType("int");
//             entity.Property(e => e.Schedule).HasMaxLength(50).IsRequired(false);
//
//             entity.HasOne(d => d.Geofence).WithMany(p => p.GeofenceSchedules)
//                 .HasForeignKey(d => d.GeofenceId)
//                 .HasConstraintName("FK_GeofenceSchedule_Geofence");
//         }
//     }
// }