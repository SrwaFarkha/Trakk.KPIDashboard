using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> entity)
        {
            entity.HasKey(e => e.AssetId).HasName("PRIMARY");

            entity.ToTable("Asset");

            entity.HasIndex(e => e.LatestAssetEventId, "FK_Asset_LatestAssetEvent");

            entity.HasIndex(e => e.TrakkerId, "FK_Asset_Trakker");

            entity.Property(e => e.AssetId).HasColumnType("int");
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.LatestAssetEventId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.OperationTimeCounter).HasColumnType("int");
            entity.Property(e => e.SecondsStillUntilStop).HasColumnType("int");
            entity.Property(e => e.TrakkerId).HasColumnType("int");

            entity.HasOne(d => d.LatestAssetEvent).WithMany(p => p.Assets)
                .HasForeignKey(d => d.LatestAssetEventId)
                .HasConstraintName("FK_Asset_LatestAssetEvent");

            entity.HasOne(d => d.Trakker).WithMany(p => p.Assets)
                .HasForeignKey(d => d.TrakkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asset_Trakker");
        }
    }
}