using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class PasswordRecoveryConfiguration : IEntityTypeConfiguration<PasswordRecovery>
    {
        public void Configure(EntityTypeBuilder<PasswordRecovery> entity)
        {
            entity.HasKey(e => e.PasswordRecoveryId).HasName("PRIMARY");

            entity.ToTable("PasswordRecovery");

            entity.HasIndex(e => e.AccountId, "FK_PasswordRecovery_AccountId");

            entity.Property(e => e.PasswordRecoveryId)
                .HasMaxLength(38)
                .IsFixedLength();
            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.ValidUntil).HasMaxLength(6);

            entity.HasOne(d => d.Account).WithMany(p => p.PasswordRecoveries)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_PasswordRecovery_AccountId");
        }
    }
}