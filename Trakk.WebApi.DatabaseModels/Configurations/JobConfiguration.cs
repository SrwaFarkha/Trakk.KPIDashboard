using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> entity)
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity.ToTable("Job");

            entity.HasIndex(e => e.CustomerId, "FK_Job_Customer");

            entity.HasIndex(e => e.JobIntervalTypeId, "FK_Job_JobIntervalType");

            entity.HasIndex(e => e.JobTypeId, "FK_Job_JobType");

            entity.HasIndex(e => e.AccountId, "IX_Job_AccountId");

            entity.Property(e => e.JobId).HasColumnType("int");
            entity.Property(e => e.AccountId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.ArgumentType).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.Arguments).HasColumnType("text").IsRequired(false);
            entity.Property(e => e.CreatedOn)
                .HasMaxLength(6)
                .HasDefaultValueSql("current_timestamp(6)");
            entity.Property(e => e.CustomerId).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.JobIntervalTypeId).HasColumnType("int");
            entity.Property(e => e.JobTypeId).HasColumnType("int");
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired(false);
            entity.Property(e => e.NextOccurrence).HasMaxLength(6);
            entity.Property(e => e.OdometerMeter).HasColumnType("int").IsRequired(false);
            entity.Property(e => e.OperationTimeHours).HasPrecision(18, 4).IsRequired(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Jobs).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Job_Customer");

            entity.HasOne(d => d.JobIntervalType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobIntervalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_JobIntervalType");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_JobType");

            entity.HasMany(d => d.Assets).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobAssetMap",
                    r => r.HasOne<Asset>().WithMany()
                        .HasForeignKey("AssetId")
                        .HasConstraintName("FK_JobAssetMap_Asset"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_JobAssetMap_Job"),
                    j =>
                    {
                        j.HasKey("JobId", "AssetId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("JobAssetMap");
                        j.HasIndex(new[] { "AssetId" }, "FK_JobAssetMap_Asset");
                    });

            entity.HasMany(d => d.Contacts).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobContactMap",
                    r => r.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_JobContactMap_Contact"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_JobContactMap_Task"),
                    j =>
                    {
                        j.HasKey("JobId", "ContactId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("JobContactMap");
                        j.HasIndex(new[] { "ContactId" }, "FK_JobContactMap_Contact");
                    });

            entity.HasMany(d => d.Groups).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobGroupMap",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_JobGroupMap_Group"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_JobGroupMap_Job"),
                    j =>
                    {
                        j.HasKey("JobId", "GroupId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("JobGroupMap");
                        j.HasIndex(new[] { "GroupId" }, "FK_JobGroupMap_Group");
                    });

            entity.HasMany(d => d.Trakkers).WithMany(p => p.Jobs)
                .UsingEntity<Dictionary<string, object>>(
                    "JobTrakkerMap",
                    r => r.HasOne<Trakker>().WithMany()
                        .HasForeignKey("TrakkerId")
                        .HasConstraintName("FK_JobTrakkerMap_Trakker"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK_JobTrakkerMap_Task"),
                    j =>
                    {
                        j.HasKey("JobId", "TrakkerId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("JobTrakkerMap");
                        j.HasIndex(new[] { "TrakkerId" }, "FK_JobTrakkerMap_Trakker");
                    });
        }
    }
}