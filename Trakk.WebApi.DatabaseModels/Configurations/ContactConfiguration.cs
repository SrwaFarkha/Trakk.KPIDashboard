using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Converters;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.HasKey(e => e.ContactId).HasName("PRIMARY");

            entity.ToTable("Contact");

            entity.HasIndex(e => e.CustomerId, "FK_Contact_Customer");

            entity.Property(e => e.ContactId).HasColumnType("int"); 
            entity.Property(e => e.AlertTypes).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.Email).IsRequired(false).HasMaxLength(255);
            entity.Property(e => e.Name).IsRequired(false).HasColumnType("text");
            entity.Property(e => e.Number).IsRequired(false).HasMaxLength(255);

            entity.Property(x => x.AlertTypes).HasConversion<EnumValueConverter<Enums.AlertTypes>>();

            entity.HasOne(d => d.Customer).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_Customer");

            entity.HasMany(d => d.Groups).WithMany(p => p.Contacts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContactGroupMap",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_ContactGroupMap_Group"),
                    l => l.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_ContactGroupMap_Contact"),
                    j =>
                    {
                        j.HasKey("ContactId", "GroupId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("ContactGroupMap");
                        j.HasIndex(new[] { "GroupId" }, "FK_ContactGroupMap_Group");
                    });

        }
    }
}