using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CustomerServiceMapConfiguration : IEntityTypeConfiguration<CustomerServiceMap>
    {
        public void Configure(EntityTypeBuilder<CustomerServiceMap> entity)
        {
            entity.HasKey(e => new { e.CustomerId, e.ServiceId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("CustomerServiceMap");

            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.ServiceId).HasColumnType("int");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.ValidUntil).HasMaxLength(6).IsRequired(false);
            entity.Property(e => e.ValueData).HasColumnType("text").IsRequired(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerServiceMaps)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerServiceMap_UserAccount");

            entity.HasOne(d => d.Service).WithMany(p => p.CustomerServiceMaps)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerServiceMap_Service");
        }
    }
}