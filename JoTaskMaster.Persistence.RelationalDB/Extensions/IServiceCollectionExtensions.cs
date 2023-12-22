using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Persistence.RelationalDB.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = null;
            if (Environment.GetEnvironmentVariable("DB_SERVER") is null)
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            else
            {
                connectionString = $" Server = {Environment.GetEnvironmentVariable("DB_SERVER")};" +
                                   $" Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
                                   $" User Id={Environment.GetEnvironmentVariable("DB_USER")};" +
                                   $" Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
                                   $" MultipleActiveResultSets=True; " +
                                   $"TrustServerCertificate=True"; //configuration.GetConnectionString("DefaultConnection");
            }

            services.AddDbContext<JoTaskMasterDbContext>(options => 
            options.UseSqlServer(connectionString,
            builder => builder.MigrationsAssembly(typeof(JoTaskMasterDbContext).Assembly.FullName)));
            
        }
    }
}
