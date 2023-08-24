using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("Category");

            entity.HasIndex(e => e.CategoryTypeId, "FK_CategoryType");

            entity.Property(e => e.CategoryId).HasColumnType("int");
            entity.Property(e => e.CategoryTypeId).HasColumnType("int");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);

            entity.HasOne(d => d.CategoryType).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CategoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryType");

            entity.HasMany(d => d.Assets).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryAssetMap",
                    r => r.HasOne<Asset>().WithMany()
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_CategoryAssetMap_Asset"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_CategoryAssetMap_Category"),
                    j =>
                    {
                        j.HasKey("CategoryId", "AssetId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("CategoryAssetMap");
                        j.HasIndex(new[] { "AssetId" }, "FK_CategoryAssetMap_Asset");
                    });

            entity.HasMany(d => d.Trakkers).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryTrakkerMap",
                    r => r.HasOne<Trakker>().WithMany()
                        .HasForeignKey("TrakkerId")
                        .HasConstraintName("FK_CategoryTrakkerMap_Trakker"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_CategoryTrakkerMap_Category"),
                    j =>
                    {
                        j.HasKey("CategoryId", "TrakkerId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("CategoryTrakkerMap");
                        j.HasIndex(new[] { "TrakkerId" }, "FK_CategoryTrakkerMap_Trakker");
                    });

            entity.HasMany(d => d.Vehicles).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryVehicleMap",
                    r => r.HasOne<Vehicle>().WithMany()
                        .HasForeignKey("VehicleId")
                        .HasConstraintName("FK_CategoryVehicleMap_Vehicle"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_CategoryVehicleMap_Category"),
                    j =>
                    {
                        j.HasKey("CategoryId", "VehicleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("CategoryVehicleMap");
                        j.HasIndex(new[] { "VehicleId" }, "FK_CategoryVehicleMap_Vehicle");
                    });
        }
    }
}