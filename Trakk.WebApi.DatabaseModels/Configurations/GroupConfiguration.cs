using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.HasKey(e => e.GroupId).HasName("PRIMARY");

            entity.ToTable("Group");

            entity.HasIndex(e => e.CustomerId, "FK_Group_Customer");

            entity.Property(e => e.GroupId).HasColumnType("int");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Groups)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_Customer");
        }
    }
}