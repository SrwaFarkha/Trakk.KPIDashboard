using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountConfirmationConfiguration : IEntityTypeConfiguration<AccountConfirmation>
    {
        public void Configure(EntityTypeBuilder<AccountConfirmation> entity)
        {
            entity.HasKey(e => new { e.AccountConfirmationId, e.AccountId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("AccountConfirmation");

            entity.HasIndex(e => e.AccountId, "FK_AccountConfirmation_Account");

            entity.Property(e => e.AccountConfirmationId)
                .HasMaxLength(38)
                .IsFixedLength();
            entity.Property(e => e.AccountId).HasColumnType("int");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountConfirmations)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_AccountConfirmation_Account");
        }
    }
}