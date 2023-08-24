using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class DriverEventTypeConfiguration : IEntityTypeConfiguration<DriverEventType>
    {
        public void Configure(EntityTypeBuilder<DriverEventType> entity)
        {
            entity.HasKey(e => e.DriverEventTypeId).HasName("PRIMARY");

            entity.ToTable("DriverEventType");

            entity.Property(e => e.DriverEventTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}