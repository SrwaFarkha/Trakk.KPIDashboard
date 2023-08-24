using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> entity)
        {
            entity.HasKey(e => e.SalesPersonId).HasName("PRIMARY");

            entity.ToTable("SalesPerson");

            entity.HasIndex(e => e.CustomerAdminId, "IX_SalesPerson_CustomerAdminId");

            entity.HasIndex(e => new { e.Name, e.CustomerAdminId }, "IX_SalesPerson_Name_CustomerAdminId")
                .IsUnique()
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 255, 0 });

            entity.Property(e => e.SalesPersonId).HasColumnType("int");
            entity.Property(e => e.CustomerAdminId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(450).IsRequired(false);

            entity.HasOne(d => d.CustomerAdmin).WithMany(p => p.SalesPersons).HasForeignKey(d => d.CustomerAdminId);

        }
    }
}
