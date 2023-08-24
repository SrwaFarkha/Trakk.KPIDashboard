using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.Minimal.Api.Extensions;

public static class VariousExtensions
{
    public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<TrakkDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("TNTDB5Context"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("TNTDB5Context")),
                    x =>
                    {
                        x.UseNetTopologySuite();
                        x.EnableRetryOnFailure(10);
                        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
            });

    }
}