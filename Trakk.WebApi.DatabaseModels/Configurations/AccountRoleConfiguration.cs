using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountRoleConfiguration : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> entity)
        {
            entity.HasKey(e => e.AccountRoleId).HasName("PRIMARY");

            entity.ToTable("AccountRole");

            entity.Property(e => e.AccountRoleId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        }
    }
}