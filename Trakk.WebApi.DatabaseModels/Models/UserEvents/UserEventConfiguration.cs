using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Trakk.Utils.Extensions.StringExtensions;

namespace Trakk.WebApi.DatabaseModels.Models.UserEvents;

public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
{
    public void Configure(EntityTypeBuilder<UserEvent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();
        builder.HasDiscriminator(x => x.EventType)
            .HasValue<UpdatePropertiesUserEvent>(UserEventType.PropertyChanged)
            .HasValue<UserLoginEvent>(UserEventType.Login);
    }
}
public class UpdatePropertiesUserEventConfiguration : IEntityTypeConfiguration<UpdatePropertiesUserEvent>
{
    public void Configure(EntityTypeBuilder<UpdatePropertiesUserEvent> builder)
    {
        builder.Property(x => x.Properties).HasConversion(
            x => x.ToJson(false),
            x => JsonConvert.DeserializeObject<List<UpdatedProperty>>(x));
    }
}