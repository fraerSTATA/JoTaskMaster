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
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<JoTaskMasterDbContext>(options => 
            options.UseSqlServer(connectionString,
            builder => builder.MigrationsAssembly(typeof(JoTaskMasterDbContext).Assembly.FullName)));
            
        }
    }
}
