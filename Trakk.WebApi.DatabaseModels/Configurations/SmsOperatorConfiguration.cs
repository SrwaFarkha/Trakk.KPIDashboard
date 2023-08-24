using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class SmsOperatorConfiguration : IEntityTypeConfiguration<SmsOperator>
    {
        public void Configure(EntityTypeBuilder<SmsOperator> entity)
        {
            entity.HasKey(e => e.SmsOperatorId).HasName("PRIMARY");

            entity.ToTable("SmsOperator");

            entity.Property(e => e.SmsOperatorId).HasColumnType("int");
            entity.Property(e => e.Apn).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired(false);
            entity.Property(e => e.Password).HasMaxLength(100).IsRequired(false);
            entity.Property(e => e.User).HasMaxLength(100).IsRequired(false);
        }
    }
}