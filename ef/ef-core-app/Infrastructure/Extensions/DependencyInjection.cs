using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSqlDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.AddDbContext<FootballLeageDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SqlDatabaseConnectionString");
                options.UseSqlServer(connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    ;

                //if (environment.IsDevelopment())
                //{
                    options.LogTo(Console.WriteLine, LogLevel.Information);

                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                //}
            });
        }
    }
}
