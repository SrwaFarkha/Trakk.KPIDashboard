using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class AssetEventConfiguration : IEntityTypeConfiguration<AssetEvent>
    {
        public void Configure(EntityTypeBuilder<AssetEvent> entity)
        {
            entity.HasKey(e => e.AssetEventId).HasName("PRIMARY");

            entity.ToTable("AssetEvent");

            entity.HasIndex(e => e.PositionId, "FK_AssetEvent_Position");

            entity.HasIndex(e => new { e.AssetId, e.AssetEventTypeId, e.StartDateTime, e.StopDateTime, e.AssetEventId, e.PositionId, e.GeofenceName, e.Comment }, "IX_AssetEvent_AssetId_AssetTypeId_Start_Stop");

            entity.Property(e => e.AssetEventId).HasColumnType("int");
            entity.Property(e => e.AssetEventTypeId).HasColumnType("int");
            entity.Property(e => e.AssetId).HasColumnType("int");
            entity.Property(e => e.PositionId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.PositionOn).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.PrivateOperationTime).HasColumnType("bigint(20)");
            entity.Property(e => e.StartDateTime).HasMaxLength(6);
            entity.Property(e => e.StopDateTime).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.WorkOperationTime).HasColumnType("bigint(20)");
            entity.Property(e => e.Comment).HasColumnType("varchar(255)").IsRequired(false);
            entity.Property(e => e.GeofenceName).HasColumnType("varchar(255)").IsRequired(false);
            
            entity.HasOne(d => d.Asset).WithMany(p => p.AssetEvents)
                .HasForeignKey(d => d.AssetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetEvent_Asset");

            entity.HasOne(d => d.Position).WithMany(p => p.AssetEvents)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_AssetEvent_Position").IsRequired(false);
        }
    }
}