using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

namespace Trakk.WebApi.DatabaseModels.Configurations
{
    public class IsaEventConfiguration : IEntityTypeConfiguration<IsaEvent>
    {
        public void Configure(EntityTypeBuilder<IsaEvent> entity)
        {
            
            entity.HasIndex(i => new { i.VehicleEventId, i.Id });
            entity.HasIndex(i => new { i.VehicleEventId });

            //entity.HasMany<EventPosition>().WithOne().HasForeignKey(x => x.IsaEventId);
        }
    }
}