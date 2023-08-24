using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Trakk.WebApi.DatabaseModels.Models;

public class ExternalAccessMap
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ExternalCustomerId { get; set; }
}

public class ExternalAccessMapConfiguration : IEntityTypeConfiguration<ExternalAccessMap>
{
    public void Configure(EntityTypeBuilder<ExternalAccessMap> builder)
    {
        builder.HasKey(x => new { x.ExternalCustomerId, x.CustomerId });
    }
}