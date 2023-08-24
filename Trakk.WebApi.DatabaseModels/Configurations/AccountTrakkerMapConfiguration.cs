using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AccountTrakkerMapConfiguration : IEntityTypeConfiguration<AccountTrakkerMap>
    {
        public void Configure(EntityTypeBuilder<AccountTrakkerMap> entity)
        {
            entity.HasKey(e => new { e.AccountId, e.TrakkerId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("AccountTrakkerMap");

            entity.HasIndex(e => e.TrakkerId, "FK_AccountTrakkerMap_Trakker");

            entity.Property(e => e.AccountId).HasColumnType("int");
            entity.Property(e => e.TrakkerId).HasColumnType("int");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountTrakkerMaps)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_AccountTrakkerMap_Account");

            entity.HasOne(d => d.Trakker).WithMany(p => p.AccountTrakkerMaps)
                .HasForeignKey(d => d.TrakkerId)
                .HasConstraintName("FK_AccountTrakkerMap_Trakker");
        }
    }
}