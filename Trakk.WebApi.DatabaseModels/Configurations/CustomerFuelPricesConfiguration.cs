using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CustomerFuelPricesConfiguration : IEntityTypeConfiguration<CustomerFuelPrice>
    {
        public void Configure(EntityTypeBuilder<CustomerFuelPrice> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CustomerId, "IX_CustomerFuelPrices_CustomerId");

            entity.Property(e => e.Id).HasColumnType("int");
            entity.Property(e => e.CreatedOn).HasMaxLength(6);
            entity.Property(e => e.CustomerId).HasColumnType("int");

            entity.HasOne(d => d.Customer).WithMany(p => p.FuelTypePrices).HasForeignKey(d => d.CustomerId);

        }
    }
}