using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class HardwareTypeConfiguration : IEntityTypeConfiguration<HardwareType>
    {
        public void Configure(EntityTypeBuilder<HardwareType> entity)
        {
            entity.HasKey(e => e.HardwareTypeId).HasName("PRIMARY");

            entity.ToTable("HardwareType");

            entity.Property(e => e.HardwareTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.HasSimCardSlot)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.Url).HasMaxLength(250).IsRequired(false);
        }
    }
}