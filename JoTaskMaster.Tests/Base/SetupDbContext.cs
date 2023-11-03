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
            //act
            var options = new DbContextOptionsBuilder<JoTaskMasterDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new JoTaskMasterDbContext(options);

            context.Database.EnsureCreated();

            context.Roles.Add(new Role
            {
                Id = 1,
                RoleName = "user",
                CreatedDate = DateTime.Now
            });

            context.Companies.Add(new Company
            {
                Id = 1,
                CompanyName = "Apple",
                CreatedDate = DateTime.Now
            });

            context.LifecycleMethods.Add(new LifecycleMethod
            {
                Id = 1,
                MethodName = "Scrum",
                CreatedDate = DateTime.Now
            });

            context.Users.AddRange(
                new User
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UserName = "Alex",
                    UserRoleId = 1,
                    UserSurname = "Smirnov",
                    UserCompanyId = 1,
                    Email = "qwe@gmail.ru",
                    Password = "12345678",
                    Nickname = "Vaerus",
                    RegistryDate = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UserName = "Sergei",
                    UserRoleId = 1,
                    UserSurname = "Smirnov",
                    UserCompanyId = 1,
                    Email = "qwerty@gmail.ru",
                    Password = "12345678",
                    Nickname = "Vaerusich",
                    RegistryDate = DateTime.UtcNow
                });

            context.StatusTypes.AddRange(new StatusType
            {
                Id = 1,
                StatusName = "Develop"
            });

            context.Projects.AddRange(
                new Project
                {
                    Id = 1,
                    ProjectModelId = 1,
                    ProjectName = "AppleTV",
                    StatusId = 1,
                    Description = "The best tv ever",
                    CreatedDate = DateTime.Now,
                    UserManagerId = 1
                },
                new Project
                {
                    Id = 2,
                    ProjectModelId = 1,
                    ProjectName = "Netflix",
                    StatusId = 1,
                    Description = "The best streaming service ever",
                    CreatedDate = DateTime.Now,
                    UserManagerId = 1,
                }
                );

            context.ProjectTasks.AddRange(
                new ProjectTask
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    TaskDescription = "CreateTemplate",
                    TaskManagerId = 1,
                    TaskStatusId = 1,
                    TaskDate = DateTime.Now,
                    TastEndDate = new DateTime(2099, 7, 20),
                    ProjectTaskId = 1,
                    SubTaskId = null
                },

                 new ProjectTask
                 {
                     Id = 2,
                     CreatedDate = DateTime.Now,
                     TaskDescription = "CreateMovie",
                     TaskManagerId = 2,
                     TaskStatusId = 1,
                     TaskDate = DateTime.Now,
                     TastEndDate = new DateTime(2099, 7, 20),
                     ProjectTaskId = 2,
                     SubTaskId = null
                 },

                  new ProjectTask
                  {
                      Id = 3,
                      CreatedDate = DateTime.Now,
                      TaskDescription = "CreatNet",
                      TaskManagerId = 1,
                      TaskStatusId = 1,
                      TaskDate = DateTime.Now,
                      TastEndDate = new DateTime(2099, 7, 20),
                      ProjectTaskId = 2,
                      SubTaskId = 2
                  }
                );

            context.SaveChanges();
            return context;

        }

        public static void DeleteDatabase(JoTaskMasterDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
