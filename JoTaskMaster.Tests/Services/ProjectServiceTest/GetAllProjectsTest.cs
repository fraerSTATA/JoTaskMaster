using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Services;
using JoTaskMaster.Persistence.RelationalDB;
using JoTaskMaster.Tests.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.Services.ProjectServiceTest
{
    public class GetAllProjectsTest
    {
        private JoTaskMasterDbContext? _context;

        [Fact]
        public void GetAllProjects_Return_Project_Success()
        {
            //Arrange

            _context = SetupDbContext.SetupContext();
            ProjectService ps = new(_context);
            PrepareData(_context);
            _context.SaveChanges();

            _context.Projects.AddRange(
                     new Project()
                     {
                         Id = 1,
                         UserManagerId = 1,
                         StatusId = 1,
                         ProjectModelId = 1,
                         Description = "test",
                         ProjectName = "Test"
                     },
                    new Project()
                    {
                        Id = 2,
                        UserManagerId = 1,
                        StatusId = 1,
                        ProjectModelId = 1,
                        Description = "test",
                        ProjectName = "Test"
                    });
            _context.SaveChanges();

            //Act

            var projects =  ps.GetAllProjects();

            //Assert
            Assert.Equal(_context.Projects.Count(),projects?.Count);
            SetupDbContext.DeleteDatabase(_context);
        }

        [Fact]
        public async void GetAllProjectsAsync_Return_Project_Success()
        {
            //Arrange

            _context = SetupDbContext.SetupContext();
            ProjectService ps = new(_context);
            PrepareData(_context);
            _context.SaveChanges();

            _context.Projects.AddRange(
                     new Project()
                     {
                         Id = 1,
                         UserManagerId = 1,
                         StatusId = 1,
                         ProjectModelId = 1,
                         Description = "test",
                         ProjectName = "Test"
                     },
                    new Project()
                    {
                        Id = 2,
                        UserManagerId = 1,
                        StatusId = 1,
                        ProjectModelId = 1,
                        Description = "test",
                        ProjectName = "Test"
                    });
            _context.SaveChanges();
            //Act

            var projects = await ps.GetAllProjectsAsync();

            //Assert
            Assert.Equal(_context.Projects.Count(), projects?.Count);
            SetupDbContext.DeleteDatabase(_context);
        }


        [Fact]
        public void GetAllProjects_Return_Project_Return_Null()
        {
            //Arrange

            _context = SetupDbContext.SetupContext();
            ProjectService ps = new(_context);
            PrepareData(_context);
            _context.SaveChanges();

            //Act

            var projects = ps.GetAllProjects();

            //Assert
            Assert.True(_context.Projects.IsNullOrEmpty());
            Assert.Null( projects);
            SetupDbContext.DeleteDatabase(_context);
        }


        private static void PrepareData(JoTaskMasterDbContext context)
        {
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
        }

    }
}
