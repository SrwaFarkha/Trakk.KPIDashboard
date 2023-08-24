using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountRightMapConfiguration : IEntityTypeConfiguration<AccountRightMap>
    {
        public void Configure(EntityTypeBuilder<AccountRightMap> entity)
        {
            entity.HasKey(e => new { e.AccountId, e.RightTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("AccountRightMap");

            entity.HasIndex(e => e.RightTypeId, "FK_AccountRightTypeMap_RightType");

            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.RightTypeId)
                .HasColumnType("int");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.ValidUntil).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.ValueData).HasColumnType("text").IsRequired(false);

            entity.HasOne(d => d.Account).WithMany(p => p.AccountRightMaps)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountRightMap_Account");

            entity.HasOne(d => d.RightType).WithMany(p => p.AccountRightMaps)
                .HasForeignKey(d => d.RightTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountRightTypeMap_RightType");
        }
    }
}