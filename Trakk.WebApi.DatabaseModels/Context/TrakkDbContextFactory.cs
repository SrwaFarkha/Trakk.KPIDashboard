using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Trakk.Configuration;

namespace Trakk.WebApi.DatabaseModels.Models
{

    public class TrakkDbContextFactory
    {
        private string ConnectionString { get; set; }
        public TrakkDbContextFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public TrakkDbContextFactory(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("TNTDB5Context");
        }

        public static TrakkDbContextFactory CreateFactory(string connectionStringName = "TNTDB5Context")
        {
            var connectionString = ConfigManager.Instance.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException($"No connection string '{connectionStringName}' ");
            return new TrakkDbContextFactory(connectionString);
        }
        public TrakkDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TrakkDbContext>()
                .UseMySql(
                    ConnectionString,
                    ServerVersion.AutoDetect(ConnectionString), x =>
                {
                    x.UseNetTopologySuite();
                    x.EnableRetryOnFailure(10);
                    x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                })
                .Options;

            return new TrakkDbContext(options);
        }

    }
}