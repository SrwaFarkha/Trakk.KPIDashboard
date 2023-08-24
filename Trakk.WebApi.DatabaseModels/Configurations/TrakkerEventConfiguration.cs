using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class TrakkerEventConfiguration : IEntityTypeConfiguration<TrakkerEvent>
    {
        public void Configure(EntityTypeBuilder<TrakkerEvent> entity)
        {
            entity.HasKey(e => e.TrakkerEventId).HasName("PRIMARY");

            entity.ToTable("TrakkerEvent");

            entity.HasIndex(e => e.PositionId, "FK_TrakkerEvent_Position");

            entity.HasIndex(e => e.TrakkerId, "IX_TrakkerEvent_TrakkerId");

            entity.Property(e => e.TrakkerEventId).HasColumnType("int");
            entity.Property(e => e.Accuracy).HasColumnType("tinyint(3) unsigned").IsRequired(false);
            entity.Property(e => e.AlertTypeId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Altitude).HasPrecision(8, 1).IsRequired(false);
            entity.Property(e => e.BatteryLevel).HasColumnType("tinyint(3) unsigned").IsRequired(false);
            entity.Property(e => e.Comment).HasMaxLength(250).IsRequired(false);
            entity.Property(e => e.Heading).HasPrecision(8, 1).IsRequired(false);
            entity.Property(e => e.IsAgps).HasColumnName("IsAGPS");
            entity.Property(e => e.OccuredOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.PositionId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Speed).HasPrecision(8, 1).IsRequired(false);
            entity.Property(e => e.Temperature).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.TrakkerEventTypeId).HasColumnType("int");
            entity.Property(e => e.TrakkerId).HasColumnType("int");

            entity.HasOne(d => d.Position).WithMany(p => p.TrakkerEvents)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_TrakkerEvent_Position").IsRequired(false);

            entity.HasOne(d => d.Trakker).WithMany(p => p.TrakkerEvents)
                .HasForeignKey(d => d.TrakkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrakkerEvent_Trakker");

            entity.HasMany(x => x.Extras).WithOne().HasForeignKey(x => x.TrakkerEventId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
    public class ExtrasConfiguration : IEntityTypeConfiguration<Extras>
    {
        public void Configure(EntityTypeBuilder<Extras> builder)
        {
          
        }
    }
}