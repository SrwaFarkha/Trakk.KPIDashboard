using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CommunicationEventTypeConfiguration : IEntityTypeConfiguration<CommunicationEventType>
    {
        public void Configure(EntityTypeBuilder<CommunicationEventType> entity)
        {
            entity.HasKey(e => e.CommunicationEventTypeId).HasName("PRIMARY");

            entity.ToTable("CommunicationEventType");

            entity.Property(e => e.CommunicationEventTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}