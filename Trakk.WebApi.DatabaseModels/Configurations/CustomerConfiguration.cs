using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CustomerAdminId, "FK_Customer_CustomerAdminId");

            entity.HasIndex(e => e.SalesPersonId, "IX_Customer_SalesPersonId");

            entity.HasIndex(e => e.Name, "UK_Customer_Name").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Address).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.City).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.Comment).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Country).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.CustomerAdminId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(250).IsRequired(false);
            entity.Property(e => e.SalesPersonId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.UpdatedOn).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.ZipCode).HasMaxLength(255).IsRequired(false);

            entity.HasOne(d => d.CustomerAdmin).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerAdminId)
                .HasConstraintName("FK_Customer_CustomerAdminId");

            entity.HasOne(d => d.SalesPerson)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.SalesPersonId);

            entity.HasMany(x => x.CustomerFeatures)
                .WithMany(x => x.Customers)
                .UsingEntity(x => x.ToTable("CustomerFeatureMaps"));
            entity.HasMany(x => x.ExternalAccessMaps).WithOne(x => x.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}