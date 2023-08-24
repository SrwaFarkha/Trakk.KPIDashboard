using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CongestionTaxProcessor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

namespace Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;

public class CongestionTaxData
{
    public int Id { get; set; }
    public List<Passage> Passages { get; set; } = new List<Passage>();
    [NotMapped] public double Cost => Passages.Sum(x => x.Cost);
}
public class CongestionTaxDataConfiguration : IEntityTypeConfiguration<CongestionTaxData>
{
    public void Configure(EntityTypeBuilder<CongestionTaxData> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.Property(e => e.Id).HasColumnType("int");
    }
}

public class PassageConfiguration : IEntityTypeConfiguration<Passage>
{
    public void Configure(EntityTypeBuilder<Passage> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("Passage");

        //entity.HasIndex(e => e.CongestionTaxDataId, "IX_Passage_CongestionTaxDataId");
        entity.HasIndex(e => e.VehicleEventId);

        entity.Property(e => e.Id).HasColumnType("int");
        entity.Property(e => e.Area).HasColumnType("int");
        entity.Property(e => e.VehicleEventId).HasColumnType("int");
        entity.Property(e => e.PassageTime).HasMaxLength(6);
        entity.Property(e => e.BorderCrossingId).HasColumnType("int").IsRequired(false);
        entity.Property(e => e.TaxBorder).HasColumnType("int");

        entity.HasOne<VehicleEvent>().WithMany(p => p.CongestionTaxPassages)
            .HasForeignKey(d => d.VehicleEventId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}