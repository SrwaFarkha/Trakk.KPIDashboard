using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class HardwareStatusConfiguration : IEntityTypeConfiguration<HardwareStatus>
    {
        public void Configure(EntityTypeBuilder<HardwareStatus> entity)
        {
            entity.HasKey(e => e.HardwareStatusId).HasName("PRIMARY");

            entity.ToTable("HardwareStatus");

            entity.Property(e => e.HardwareStatusId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);
        }
    }
}