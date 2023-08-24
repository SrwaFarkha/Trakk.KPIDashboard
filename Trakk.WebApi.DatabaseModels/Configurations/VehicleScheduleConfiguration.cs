using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

// namespace Trakk.WebApi.DatabaseModels.Configurations
// {
//     public class VehicleScheduleConfiguration : IEntityTypeConfiguration<VehicleSchedule>
//     {
//         public void Configure(EntityTypeBuilder<VehicleSchedule> entity)
//         {
//             entity.HasKey(e => e.VehicleScheduleId).HasName("PRIMARY");
//
//             entity.ToTable("VehicleSchedule");
//
//             entity.HasIndex(e => e.VehicleId, "FK_VehicleScheduleVehicle");
//
//             entity.Property(e => e.VehicleScheduleId)
//                 .ValueGeneratedNever()
//                 .HasColumnType("int");
//             entity.Property(e => e.Schedule).HasMaxLength(50).IsRequired(false);
//             entity.Property(e => e.VehicleId).HasColumnType("int");
//
//             entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleSchedules)
//                 .HasForeignKey(d => d.VehicleId)
//                 .HasConstraintName("FK_VehicleScheduleVehicle");
//         }
//     }
// }