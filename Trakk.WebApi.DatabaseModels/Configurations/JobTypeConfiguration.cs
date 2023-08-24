using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> entity)
        {
            entity.HasKey(e => e.JobTypeId).HasName("PRIMARY");

            entity.ToTable("JobType");

            entity.Property(e => e.JobTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}