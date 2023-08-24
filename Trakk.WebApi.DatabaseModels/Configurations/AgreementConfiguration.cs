using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AgreementConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> entity)
        {
            entity.HasKey(e => e.AgreementId).HasName("PRIMARY");

            entity.ToTable("Agreement");

            entity.Property(e => e.AgreementId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.AgreementNumber).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.Comment).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Finance).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Reference).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.UnitId).HasColumnType("int");
            entity.Property(e => e.ValidTo).HasMaxLength(6).IsRequired(false);
        }
    }
}