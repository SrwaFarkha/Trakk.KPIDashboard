using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> entity)
        {
            entity.HasKey(e => e.PositionId).HasName("PRIMARY");

            entity.ToTable("Position");

            entity.HasIndex(e => e.GeocodedPositionId, "FK_GeocodedPosition");

            entity.HasIndex(e => new { e.Latitude, e.Longitude, e.PositionId, e.CreatedOn, e.GeocodedPositionId }, "IX_Position_Lat_Lon");

            entity.Property(e => e.PositionId).HasColumnType("int");
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.GeocodedPositionId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Latitude).HasPrecision(9, 6);
            entity.Property(e => e.Longitude).HasPrecision(9, 6);

            entity.HasOne(d => d.GeocodedPosition).WithMany(p => p.Positions)
                .HasForeignKey(d => d.GeocodedPositionId)
                .HasConstraintName("FK_GeocodedPosition");
        }
    }
}