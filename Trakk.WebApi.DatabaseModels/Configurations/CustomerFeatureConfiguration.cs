using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Configurations;

public class CustomerFeatureConfiguration: IEntityTypeConfiguration<CustomerFeature>
{
    public void Configure(EntityTypeBuilder<CustomerFeature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever().HasColumnType("int");
        builder.Property(e => e.Name).HasMaxLength(50).IsRequired(false);
        
        builder.HasMany(x => x.AccountRights)
            .WithMany(x => x.CustomerFeatures)
            .UsingEntity(x => x.ToTable("CustomerFeatureRightMaps")
                .HasData(new { CustomerFeaturesId = Enums.CustomerFeature.SafetyZone, AccountRightsRightTypeId = Enums.AccountRight.UseSafetyZone}));
    }
}
