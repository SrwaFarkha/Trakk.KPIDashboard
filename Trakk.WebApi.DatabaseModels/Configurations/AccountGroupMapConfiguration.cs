using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountGroupMapConfiguration : IEntityTypeConfiguration<AccountGroupMap>
    {
        public void Configure(EntityTypeBuilder<AccountGroupMap> entity)
        {
            entity.HasKey(e => new { e.AccountId, e.GroupId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("AccountGroupMap");

            entity.HasIndex(e => e.GroupId, "FK_AccountGroupMap_Group");

            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.GroupId).HasColumnType("int");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountGroupMaps)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_AccountGroupMap_Account");

            entity.HasOne(d => d.Group).WithMany(p => p.AccountGroupMaps)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_AccountGroupMap_Group");
        }
    }
}