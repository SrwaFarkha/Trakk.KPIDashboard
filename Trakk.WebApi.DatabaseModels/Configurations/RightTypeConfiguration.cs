using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class RightTypeConfiguration : IEntityTypeConfiguration<RightType>
    {
        public void Configure(EntityTypeBuilder<RightType> entity)
        {
            entity.HasKey(e => e.RightTypeId).HasName("PRIMARY");

            entity.ToTable("RightType");

            entity.Property(e => e.RightTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}