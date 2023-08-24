using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class IconConfiguration : IEntityTypeConfiguration<Icon>
    {
        public void Configure(EntityTypeBuilder<Icon> entity)
        {
            entity.HasKey(e => e.IconId).HasName("PRIMARY");

            entity.ToTable("Icon");

            entity.Property(e => e.IconId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
            entity.Property(e => e.Url).HasColumnType("text").IsRequired(false);
        }
    }
}