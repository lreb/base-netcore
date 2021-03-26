using Base.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Extension.Database
{
    /// <summary>
    /// The Service Collection Extensions
    /// </summary>
    /// <seealso cref="IServiceCollection"/>
    public static class PostgreSQLExtension
    {
        /// <summary>
        /// Set up the Service PostgreSQL DB Context
        /// </summary>
        /// <param name="serviceCollection">The <see cref="IServiceCollection"/></param>
        /// <param name="configuration">The data migration connection string <see cref="IConfiguration"/></param>
        /// <param name="configRoot">The data migration connection string <see cref="IConfigurationRoot"/></param>
        public static void UsePostgreSqlServer(this IServiceCollection serviceCollection, string connectionString)
        //IConfiguration configuration, IConfigurationRoot configRoot)
        {
            // https://www.npgsql.org/efcore/api/Microsoft.Extensions.DependencyInjection.NpgsqlServiceCollectionExtensions.html#Microsoft_Extensions_DependencyInjection_NpgsqlServiceCollectionExtensions_AddEntityFrameworkNpgsql_IServiceCollection_
            // https://www.npgsql.org/efcore/index.html#additional-configuration-for-aspnet-core-applications

            // TODO: use your context
            //serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(applicationConfigurationConnectionString));

            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                  //options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection") ?? configRoot["ConnectionStrings:PostgreSqlConnection"]
                  options.UseNpgsql(connectionString
                  , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

    }
}
