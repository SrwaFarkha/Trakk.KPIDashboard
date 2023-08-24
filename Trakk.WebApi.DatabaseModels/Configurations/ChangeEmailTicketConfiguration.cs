using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class ChangeEmailTicketConfiguration : IEntityTypeConfiguration<ChangeEmailTicket>
    {
        public void Configure(EntityTypeBuilder<ChangeEmailTicket> entity)
        {
            entity.HasKey(e => e.ChangeEmailTicketId).HasName("PRIMARY");

            entity.ToTable("ChangeEmailTicket");

            entity.HasIndex(e => e.AccountId, "FK_ChangeEmailTicket_Account");

            entity.HasIndex(e => e.Verification, "IX_ChangeEmailTicket_Verification");

            entity.Property(e => e.ChangeEmailTicketId).HasColumnType("int");
            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.NewEmail).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.OldEmail).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.ValidUntil)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.Verification)
                .HasMaxLength(38)
                .HasDefaultValueSql("(uuid())")
                .IsFixedLength();

            entity.HasOne(d => d.Account).WithMany(p => p.ChangeEmailTickets)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_ChangeEmailTicket_Account");
        }
    }
}