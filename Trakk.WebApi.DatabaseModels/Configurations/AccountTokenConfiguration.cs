using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountTokenConfiguration : IEntityTypeConfiguration<AccountToken>
    {
        public void Configure(EntityTypeBuilder<AccountToken> entity)
        {
            entity.HasKey(e => e.AccountTokenId).HasName("PRIMARY");

            entity.ToTable("AccountToken");

            entity.HasIndex(e => e.TokenGuid, "UQ_AccountToken_TokenGuid").IsUnique();

            entity.Property(e => e.AccountTokenId).HasColumnType("int");
            entity.Property(e => e.Token).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.TokenGuid)
                .HasMaxLength(38)
                .IsFixedLength();
        }
    }
}