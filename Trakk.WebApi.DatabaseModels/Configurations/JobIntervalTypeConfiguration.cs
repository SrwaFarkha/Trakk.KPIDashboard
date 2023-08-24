using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class JobIntervalTypeConfiguration : IEntityTypeConfiguration<JobIntervalType>
    {
        public void Configure(EntityTypeBuilder<JobIntervalType> entity)
        {
            entity.HasKey(e => e.JobIntervalTypeId).HasName("PRIMARY");

            entity.ToTable("JobIntervalType");

            entity.Property(e => e.JobIntervalTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
        }
    }
}