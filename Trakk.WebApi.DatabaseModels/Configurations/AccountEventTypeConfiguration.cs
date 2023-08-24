using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountEventTypeConfiguration : IEntityTypeConfiguration<AccountEventType>
    {
        public void Configure(EntityTypeBuilder<AccountEventType> entity)
        {
            entity.HasKey(e => e.AccountEventTypeId).HasName("PRIMARY");

            entity.ToTable("AccountEventType");

            entity.Property(e => e.AccountEventTypeId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}