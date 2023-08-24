using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");

            entity.ToTable("Account");

            entity.HasIndex(e => e.ContactId, "FK_Account_Contact");

            entity.HasIndex(e => e.CustomerId, "FK_Account_Customer");

            entity.HasIndex(e => e.LanguageId, "FK_Account_Language");

            entity.HasIndex(e => e.AccountRoleId, "FK_Account_UserRole");

            entity.HasIndex(e => e.Email, "IX_Account_Email_NullableUnique")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.HasIndex(e => e.LoginName, "UQ_Account_LoginName")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255 });

            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.AccountRoleId).HasColumnType("int");
            entity.Property(e => e.ContactId).HasColumnType("int");
            entity.Property(e => e.CreatedOn).HasMaxLength(6);
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Email).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.Guid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("GUID");
            entity.Property(e => e.HomeLatitude).HasPrecision(9, 6).IsRequired(false);
            entity.Property(e => e.HomeLongitude).HasPrecision(9, 6).IsRequired(false);
            entity.Property(e => e.IconSizePixels)
                .HasDefaultValueSql("'32'")
                .HasColumnType("int");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.LanguageId).HasColumnType("int");
            entity.Property(e => e.LoginName).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.PasswordEncrypted).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.SpeedUnit)
                .HasMaxLength(10)
                .HasDefaultValueSql("'kmh'").IsRequired(false);
            entity.Property(e => e.TimeZoneId)
                .HasMaxLength(250)
                .HasDefaultValueSql("'UTC'").IsRequired(false);
            entity.Property(e => e.UpdatedOn).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.ValidUntil).HasMaxLength(6).IsRequired(false);

            entity.HasOne(d => d.AccountRole).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_UserRole");

            entity.HasOne(d => d.Contact).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Contact");

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Customer");

            entity.HasOne(d => d.Language).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Language");
        }
    }
}