using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CommunicationEventConfiguration : IEntityTypeConfiguration<CommunicationEvent>
    {
        public void Configure(EntityTypeBuilder<CommunicationEvent> entity)
        {
            entity.HasKey(e => e.CommunicationEventId).HasName("PRIMARY");

            entity.ToTable("CommunicationEvent");

            entity.HasIndex(e => e.AccountId, "FK_CommunicationEvent_Account");

            entity.HasIndex(e => e.CommunicationEventTypeId, "FK_CommunicationEvent_CommunicationEventType");

            entity.Property(e => e.CommunicationEventId).HasColumnType("int");
            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.CommunicationEventTypeId).HasColumnType("int");
            entity.Property(e => e.CreatedOn).HasMaxLength(6);
            entity.Property(e => e.Message).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Receiver).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.Sender).HasMaxLength(256).IsRequired(false);
            entity.Property(e => e.Subject).HasMaxLength(255).IsRequired(false);

            entity.HasOne(d => d.Account).WithMany(p => p.CommunicationEvents)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunicationEvent_Account");

            entity.HasOne(d => d.CommunicationEventType).WithMany(p => p.CommunicationEvents)
                .HasForeignKey(d => d.CommunicationEventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommunicationEvent_CommunicationEventType");
        }
    }
}