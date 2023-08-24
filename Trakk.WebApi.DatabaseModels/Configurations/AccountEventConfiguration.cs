using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountEventConfiguration : IEntityTypeConfiguration<AccountEvent>
    {
        public void Configure(EntityTypeBuilder<AccountEvent> entity)
        {
            entity.HasKey(e => e.AccountEventId).HasName("PRIMARY");

            entity.ToTable("AccountEvent");

            entity.HasIndex(e => e.AccountId, "FK_AccountEvent_Account");

            entity.HasIndex(e => e.AccountEventTypeId, "FK_AccountEvent_EventType");

            entity.Property(e => e.AccountEventId).HasColumnType("int");
            entity.Property(e => e.AccountEventTypeId).HasColumnType("int");
            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.CreatedOn).HasMaxLength(6);
            entity.Property(e => e.EventData).HasColumnType("text").IsRequired(false);

            entity.HasOne(d => d.AccountEventType).WithMany(p => p.AccountEvents)
                .HasForeignKey(d => d.AccountEventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountEvent_EventType");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountEvents)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_AccountEvent_Account");
        }
    }
}