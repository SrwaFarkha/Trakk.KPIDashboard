using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class GeofenceTypeConfiguration : IEntityTypeConfiguration<GeofenceType>
    {
        public void Configure(EntityTypeBuilder<GeofenceType> entity)
        {
            entity.HasKey(e => e.GeofenceTypeId).HasName("PRIMARY");

            entity.ToTable("GeofenceType");

            entity.Property(e => e.GeofenceTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}