using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class MapzoneConfiguration : IEntityTypeConfiguration<Mapzone>
    {
        public void Configure(EntityTypeBuilder<Mapzone> entity)
        {
            entity.HasKey(e => e.MapzoneId).HasName("PRIMARY");

            entity.ToTable("Mapzone");

            entity.HasIndex(e => e.CustomerId, "FK_Mapzone_Customer");

            entity.Property(e => e.MapzoneId).HasColumnType("int");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Latitude).HasPrecision(9, 6);
            entity.Property(e => e.Longitude).HasPrecision(9, 6);
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.ZoomLevel).HasColumnType("int");

            entity.HasOne(d => d.Customer).WithMany(p => p.Mapzones)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mapzone_Customer");
        }
    }
}