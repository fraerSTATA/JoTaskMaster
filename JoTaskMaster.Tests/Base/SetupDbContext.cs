using JoTaskMaster.Persistence.RelationalDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JoTaskMaster.Domain.Entities;


namespace JoTaskMaster.Tests.Base
{
    public static class SetupDbContext
    {
        public static JoTaskMasterDbContext SetupContext()
        {
            var options = new DbContextOptionsBuilder<JoTaskMasterDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new JoTaskMasterDbContext(options);

            context.Database.EnsureCreated();

            return context;

        }

        public static void DeleteDatabase(JoTaskMasterDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
