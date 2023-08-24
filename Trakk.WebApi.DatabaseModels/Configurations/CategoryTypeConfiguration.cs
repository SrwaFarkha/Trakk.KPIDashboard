using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> entity)
        {
            entity.HasKey(e => e.CategoryTypeId).HasName("PRIMARY");

            entity.ToTable("CategoryType");

            entity.Property(e => e.CategoryTypeId)
                .HasColumnType("int");
            entity.Property(e => e.CustomerId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
        }
    }
}