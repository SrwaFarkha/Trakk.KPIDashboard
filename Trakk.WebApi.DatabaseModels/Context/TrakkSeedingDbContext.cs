using Microsoft.EntityFrameworkCore;
using Trakk.WebApi.DatabaseModels.Models;
using Trakk.WebApi.DatabaseModels.Seeding;

namespace Trakk.WebApi.DatabaseModels.Context;

public class TrakkSeedingDbContext : TrakkDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplySeedData();
    }
}


public class PopulatedDbContext : TrakkDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplySeedData();

        modelBuilder.PopulateDb();
    }

}