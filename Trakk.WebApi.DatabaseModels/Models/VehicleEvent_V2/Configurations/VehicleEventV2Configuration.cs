using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2.Configurations;

public class VehicleEventV2Configuration : IEntityTypeConfiguration<VehicleEvent>
{
    public void Configure(EntityTypeBuilder<VehicleEvent> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        
        builder.HasDiscriminator<Enums.VehicleEventType_V2>(x => x.Type)
            .HasValue<TripEvent>(Enums.VehicleEventType_V2.Trip)
            .HasValue<StopEvent>(Enums.VehicleEventType_V2.Stop)
            .HasValue<UserStopEvent>(Enums.VehicleEventType_V2.ManualStop)
            .HasValue<UserTripEvent>(Enums.VehicleEventType_V2.ManualTrip);
        
        builder.HasIndex(e => e.AccountId, "IX_VehicleEvents_AccountId");
       // builder.HasIndex(e => e.CongestionTaxDataId, "IX_VehicleEvents_CongestionTaxDataId").IsUnique();
        builder.HasIndex(e => e.PreviousId, "IX_VehicleEvents_PreviousId").IsUnique();
        builder.HasIndex(e => e.RouteId, "IX_VehicleEvents_RouteId").IsUnique();
        builder.HasIndex(e => e.VehicleId, "IX_VehicleEvents_VehicleId");
        builder.HasIndex(v => new { v.Id, v.Type, v.VehicleId });

        builder.Property(e => e.Id).HasColumnType("int");
        builder.Property(e => e.AccountId).HasColumnType("int").IsRequired(false);
        builder.Property(e => e.Comment).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.Driver).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.HardwareType).HasColumnType("int");
        builder.Property(e => e.OdometerMeter).HasColumnType("int").IsRequired(false);
        builder.Property(e => e.PositionCount).HasColumnType("int");
        builder.Property(e => e.PreviousId).HasColumnType("int").IsRequired(false);
        builder.Property(e => e.RouteId).HasColumnType("int").IsRequired(false);
        builder.Property(e => e.StartTime).HasMaxLength(6);
        builder.Property(e => e.Type).HasColumnType("int");
        builder.Property(e => e.VehicleId).HasColumnType("int");
        
        
        // builder.HasOne(x => x.Next).WithOne(x => x.Previous)
        //     .IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        // builder.HasOne(x => x.Previous)
        //     .WithOne(x => x. Next).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        // builder.HasMany(x => x.Positions).WithOne().HasForeignKey(x => x.VehicleEventId);
        // builder.HasOne(a => a.Vehicle)
        //     .WithMany(b => b.VehicleEvents)
        //     .HasForeignKey(c => c.VehicleId).OnDelete(DeleteBehavior.Cascade);
        // builder.HasOne(x => x.CongestionTaxData).WithOne()
        //     .HasForeignKey<VehicleEvent>(x => x.CongestionTaxDataId)
        //     .IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        // builder.HasOne(a => a.Account).WithMany().OnDelete(DeleteBehavior.SetNull);
        //
        builder.HasOne(d => d.Account).WithMany()
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.SetNull).IsRequired(false);
        builder.HasOne(d => d.Previous).WithOne(p => p.Next)
            .HasForeignKey<VehicleEvent>(d => d.PreviousId).IsRequired(false);
        builder.HasOne(d => d.Route).WithOne()
            .HasForeignKey<VehicleEvent>(d => d.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(d => d.Vehicle)
            .WithMany(p => p.VehicleEvents)
            .HasForeignKey(d => d.VehicleId);


    }
}
public class StopEventConfiguration : IEntityTypeConfiguration<StopEvent>
{
    public void Configure(EntityTypeBuilder<StopEvent> builder)
    {
        builder.HasIndex(e => e.StopPositionId, "IX_VehicleEvents_StopPositionId");
        builder.Property(e => e.StopPositionId).HasColumnType("int");

        builder.HasOne(d => d.StopPosition).WithMany()
            .HasForeignKey(d => d.StopPositionId)
            .OnDelete(DeleteBehavior.SetNull);
        //builder.Navigation(x => x.StopPosition).UsePropertyAccessMode(PropertyAccessMode.Property);

    }
}

public class TripEventConfiguration : IEntityTypeConfiguration<TripEvent>
{
    public void Configure(EntityTypeBuilder<TripEvent> builder)
    {
        builder.Property(x => x.Distance).HasDefaultValue(0);
    }
}
public class EventPositionConfiguration : IEntityTypeConfiguration<EventPosition>
{
    public void Configure(EntityTypeBuilder<EventPosition> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.HasIndex(e => e.PositionId, "IX_EventPositions_PositionId");

        entity.HasIndex(e => e.VehicleEventId, "IX_EventPositions_VehicleEventId");
        entity.HasIndex(e => new { e.PositionId, e.IsaEventId, e.VehicleEventId, e.Id });

        entity.Property(e => e.Id).HasColumnType("int");
        entity.Property(e => e.PositionId).HasColumnType("int");
        entity.Property(e => e.TimeStamp).HasMaxLength(6);
        entity.Property(e => e.VehicleEventId).HasColumnType("int");
        entity.Property(e => e.IsaEventId).IsRequired(false);

        entity.HasOne(d => d.Position).WithMany().HasForeignKey(d => d.PositionId);

        entity.HasOne<VehicleEvent>().WithMany(p => p.Positions).HasForeignKey(d => d.VehicleEventId);
        entity.HasOne<IsaEvent>().WithMany(p => p.EventPositions).HasForeignKey(d => d.IsaEventId);



    }
}

