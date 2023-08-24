using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> entity)
        {
            entity.HasKey(e => e.ErrorLogId).HasName("PRIMARY");

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorLogId).HasColumnType("int");
            entity.Property(e => e.Created)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.Http).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Message).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.StackTrace).HasColumnType("text").IsRequired(false);
        }
    }
}