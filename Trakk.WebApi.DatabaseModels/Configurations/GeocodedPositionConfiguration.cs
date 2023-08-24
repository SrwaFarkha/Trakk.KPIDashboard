using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class GeocodedPositionConfiguration : IEntityTypeConfiguration<GeocodedPosition>
    {
        public void Configure(EntityTypeBuilder<GeocodedPosition> entity)
        {
            entity.HasKey(e => e.GeocodedPositionId).HasName("PRIMARY");

            entity.ToTable("GeocodedPosition");

            entity.HasIndex(e => new { e.Latitude, e.Longitude }, "IX_GeocodedPosition_Latitude_Longitude");

            entity.Property(e => e.GeocodedPositionId).HasColumnType("int");
            entity.Property(e => e.City).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Country).HasMaxLength(3).IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.HouseNumber).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Label).HasMaxLength(500).IsRequired(false);
            entity.Property(e => e.Latitude).HasPrecision(7, 4);
            entity.Property(e => e.Longitude).HasPrecision(7, 4);
            entity.Property(e => e.PostalCode).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Street).HasMaxLength(255).IsRequired(false);
        }
    }
}