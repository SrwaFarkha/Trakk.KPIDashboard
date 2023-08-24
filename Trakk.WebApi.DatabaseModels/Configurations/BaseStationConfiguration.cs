using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class BaseStationConfiguration : IEntityTypeConfiguration<BaseStation>
    {
        public void Configure(EntityTypeBuilder<BaseStation> entity)
        {
            entity.HasKey(e => e.BaseStationId).HasName("PRIMARY");

            entity.ToTable("BaseStation");

            entity.HasIndex(e => e.PositionId, "FK_BaseStation_Position");

            entity.Property(e => e.BaseStationId).HasColumnType("int");
            entity.Property(e => e.IdetityCode)
                .HasMaxLength(30)
                .HasDefaultValueSql("'MCC + MNC + LAC + CELLID'").IsRequired(false);
            entity.Property(e => e.PositionId).HasColumnType("int");

            entity.HasOne(d => d.Position).WithMany(p => p.BaseStations)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaseStation_Position");
        }
    }
}