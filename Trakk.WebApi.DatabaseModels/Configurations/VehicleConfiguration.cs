using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            entity.HasKey(e => e.VehicleId).HasName("PRIMARY");

            entity.ToTable("Vehicle");

            entity.HasIndex(e => e.CustomerId, "FK_Vehicle_Customer");

            entity.HasIndex(e => e.LatestTrakkerEventId, "FK_Vehicle_TrakkerEvent");

            entity.HasIndex(e => e.AccountId, "IX_Vehicle_AccountId").IsUnique();

            entity.HasIndex(e => e.LatestStopEventId, "IX_Vehicle_LatestStopEventId").IsUnique();

            entity.Property(e => e.VehicleId).HasColumnType("int");
            entity.Property(e => e.AccountId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Co2)
                .HasColumnType("int")
                .HasColumnName("CO2").IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Driver)
                .HasMaxLength(256)
                .HasDefaultValueSql("''").IsRequired(false);
            entity.Property(e => e.DriverAssignment).HasColumnType("int");
            entity.Property(e => e.DriverAssignmentValidUntil).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.FuelType).HasColumnType("int");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.LatestStopEventId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.LatestTrakkerEventId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.OdometerMeter).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.TimeZoneId)
                .HasMaxLength(250)
                .HasDefaultValueSql("'UTC'").IsRequired(false);
            entity.Property(e => e.VehicleRegistrationNumber).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.Vin)
                .HasMaxLength(50)
                .HasColumnName("VIN").IsRequired(false);

            entity.HasOne(d => d.Account).WithOne()
                .HasForeignKey<Vehicle>(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_Customer");

            entity.HasOne(d => d.LatestStopEvent).WithOne()
                .HasForeignKey<Vehicle>(d => d.LatestStopEventId)
                .IsRequired(false);

            entity.HasOne(d => d.LatestTrakkerEvent).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.LatestTrakkerEventId)
                .HasConstraintName("FK_Vehicle_TrakkerEvent").IsRequired(false);
        }
    }
}