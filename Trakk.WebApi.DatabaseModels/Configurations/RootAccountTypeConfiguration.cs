using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class RootAccountTypeConfiguration : IEntityTypeConfiguration<RootAccountType>
    {
        public void Configure(EntityTypeBuilder<RootAccountType> entity)
        {
            entity.HasKey(e => e.RootAccountTypeId).HasName("PRIMARY");

            entity.ToTable("RootAccountType");

            entity.Property(e => e.RootAccountTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}