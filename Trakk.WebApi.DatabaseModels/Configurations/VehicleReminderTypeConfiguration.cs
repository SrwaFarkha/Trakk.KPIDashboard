using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class VehicleReminderTypeConfiguration : IEntityTypeConfiguration<VehicleReminderType>
    {
        public void Configure(EntityTypeBuilder<VehicleReminderType> entity)
        {
            entity.HasKey(e => e.VehicleReminderTypeId).HasName("PRIMARY");

            entity.ToTable("VehicleReminderType");

            entity.Property(e => e.VehicleReminderTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}