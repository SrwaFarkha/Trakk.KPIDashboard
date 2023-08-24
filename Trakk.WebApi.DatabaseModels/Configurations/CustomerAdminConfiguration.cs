using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class CustomerAdminConfiguration : IEntityTypeConfiguration<CustomerAdmin>
    {
        public void Configure(EntityTypeBuilder<CustomerAdmin> entity)
        {
            entity.HasKey(e => e.CustomerAdminId).HasName("PRIMARY");

            entity.ToTable("CustomerAdmin");

            entity.Property(e => e.CustomerAdminId).HasColumnType("int");
            entity.Property(e => e.ContactEmail).HasMaxLength(250).IsRequired(false);
            entity.Property(e => e.ContactName).HasMaxLength(250).IsRequired(false);
            entity.Property(e => e.ContactPhoneNumber).HasMaxLength(250).IsRequired(false);
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
        }
    }
}