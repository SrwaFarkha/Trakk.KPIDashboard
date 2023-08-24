using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class DriverSettingConfiguration : IEntityTypeConfiguration<DriverSetting>
    {
        public void Configure(EntityTypeBuilder<DriverSetting> entity)
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnType("int");
            entity.Property(e => e.WorkEndFriday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkEndMonday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkEndSaturday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkEndSunday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkEndThursday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkEndTuesday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkEndWednesday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartFriday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartMonday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartSaturday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartSunday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartThursday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartTuesday).HasColumnType("time").IsRequired(false);
            entity.Property(e => e.WorkStartWednesday).HasColumnType("time").IsRequired(false);

            entity.HasOne(d => d.Account).WithOne(p => p.DriverSetting)
                .HasForeignKey<DriverSetting>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DriverSettings_Account");
        }
    }
}