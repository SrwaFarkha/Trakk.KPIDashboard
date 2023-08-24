using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class RootAccountConfiguration : IEntityTypeConfiguration<RootAccount>
    {
        public void Configure(EntityTypeBuilder<RootAccount> entity)
        {
            entity.HasKey(e => e.RootAccountId).HasName("PRIMARY");

            entity.ToTable("RootAccount");

            entity.HasIndex(e => e.CustomerAdminId, "FK_RootAccount_CustomerAdmin");

            entity.HasIndex(e => e.RootAccountTypeId, "FK_RootAccount_RootAccountType");

            entity.HasIndex(e => e.UserName, "UQ_RootAccount_UserName").IsUnique();

            entity.Property(e => e.RootAccountId).HasColumnType("int");
            entity.Property(e => e.CustomerAdminId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.RootAccountTypeId).HasColumnType("int");

            entity.HasOne(d => d.CustomerAdmin).WithMany(p => p.RootAccounts)
                .HasForeignKey(d => d.CustomerAdminId)
                .HasConstraintName("FK_RootAccount_CustomerAdmin");

            entity.HasOne(d => d.RootAccountType).WithMany(p => p.RootAccounts)
                .HasForeignKey(d => d.RootAccountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RootAccount_RootAccountType");
        }
    }
}