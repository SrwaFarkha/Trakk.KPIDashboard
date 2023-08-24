using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> entity)
        {
            // builder.ToTable("Route");
            // builder.HasKey(x => x.RouteId).HasName("PK_Route");
            // builder.Property(x => x.RouteId).HasColumnName(@"RouteId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseMySqlIdentityColumn();
            // //builder.Property(x => x.Path).HasColumnType("geometry").IsRequired();
            // builder.HasOne<VehicleEvent_V2.VehicleEvent>().WithOne(x => x.Route)
            //     .HasForeignKey<VehicleEvent_V2.VehicleEvent>(x => x.RouteId)
            //     .OnDelete(DeleteBehavior.Cascade);
            // builder.HasMany(x => x.Sections).WithOne().HasForeignKey(x => x.RouteId).OnDelete(DeleteBehavior.Cascade);
            //
            entity.HasKey(e => e.RouteId).HasName("PRIMARY");

            entity.ToTable("Route");

            entity.Property(e => e.RouteId).HasColumnType("int");
            entity.Property(e => e.RouteHandle).HasColumnType("text").IsRequired(false);
        }
    }
    public class RouteSectionConfiguration : IEntityTypeConfiguration<RouteSection>
    {
        public void Configure(EntityTypeBuilder<RouteSection> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RouteId, "IX_RouteSections_RouteId");

            entity.HasIndex(e => e.StartReferencePositionId, "IX_RouteSections_StartReferencePositionId");

            entity.HasIndex(e => e.StopReferencePositionId, "IX_RouteSections_StopReferencePositionId");

            entity.Property(e => e.Id).HasColumnType("int");
            entity.Property(e => e.From).HasMaxLength(6);
            entity.Property(e => e.RouteId).HasColumnType("int");
            entity.Property(e => e.StartReferencePositionId).HasColumnType("int");
            entity.Property(e => e.StopReferencePositionId).HasColumnType("int");
            entity.Property(e => e.To).HasMaxLength(6);

            entity.HasOne(d => d.Route).WithMany(p => p.Sections).HasForeignKey(d => d.RouteId);

            entity.HasOne(d => d.StartReferencePosition).WithMany().HasForeignKey(d => d.StartReferencePositionId);

            entity.HasOne(d => d.StopReferencePosition).WithMany().HasForeignKey(d => d.StopReferencePositionId);

            
        }
    }
}