using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class DbSettingConfiguration : IEntityTypeConfiguration<DbSetting>
    {
        public void Configure(EntityTypeBuilder<DbSetting> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DBSettings");

            entity.Property(e => e.Id).HasColumnType("int");
            entity.Property(e => e.IsIntegrationTestDb).HasColumnName("IsIntegrationTestDB");

        }
    }
}