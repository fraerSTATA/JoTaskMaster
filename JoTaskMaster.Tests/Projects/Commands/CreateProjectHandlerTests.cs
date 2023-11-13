using AutoMapper;
using FakeItEasy;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Persistence.RelationalDB;
using JoTaskMaster.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoTaskMaster.Application;
using System.Runtime.CompilerServices;
using JoTaskMaster.Application.Features.Companies.Commands.CreateCommand;
using Moq;
using JoTaskMaster.Domain.Entities;
using Microsoft.Extensions.Logging;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using System.Collections;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using System.Net.Sockets;
using System.Net;

namespace JoTaskMaster.Tests.Projects.Commands
{

    public class CreateProjectHandlerTests
    {
        private static readonly LifecycleMethod lifecycleMethod = new();
        private static readonly User user = new();
        private static readonly StatusType statusType = new();

        private readonly Mock<IProjectService> _projectServiceMock;
        private readonly Mock<ILifecycleMethodService> _lifecycleMethodServiceMock;
        private readonly Mock<IStatusTypeService> _statusTypeServiceMock;
        private readonly Mock<IUserService> _userServiceMock;
        public CreateProjectHandlerTests ()
        {
           _projectServiceMock = new Mock<IProjectService>();
           _lifecycleMethodServiceMock = new Mock<ILifecycleMethodService>();
           _statusTypeServiceMock = new Mock<IStatusTypeService>();
           _userServiceMock = new Mock<IUserService>();
        }
        
        [Fact]
        public async Task CreateProjectCommandHandler_Success()
        {

            // Arrage
           
            var createProjectCommand = new CreateProjectCommand
            {
                ProjectModelId = 1,
                Description = "Test",
                ProjectName = "Test",
                StatusId = 1,
                UserManagerId = 1,
            };
           
            _projectServiceMock.Setup(p => p.CreateProjectAsync(It.IsAny<Project>()).Result);

            var createProjectCommandHandler = new CreateProjectCommandHandler(
                                                  _projectServiceMock.Object
                                                 );
            // Act

            var res = await createProjectCommandHandler.Handle(createProjectCommand, default);

            // Assert 

            Assert.True(res.Succeeded);
            Assert.Equal("Project created", res.Messages.First());

        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public async Task CreateProjectCommandHandler_Should_Throw_Bad_Request_Exception(
                                                                LifecycleMethod? lifecycleMethod,
                                                                User? user,
                                                                StatusType? statusType,
                                                                string? Description,
                                                                string? ProjectName)
                                                                                    
        {

            // Arrage

            var createProjectCommand = new CreateProjectCommand
            {
                ProjectModelId = 1,
                Description = Description,
                ProjectName = ProjectName,
                StatusId = 1,
                UserManagerId = 1,
            };
            

            _projectServiceMock.Setup(p => p.CreateProjectAsync(It.IsAny<Project>()));

            var createProjectCommandHandler = new CreateProjectCommandHandler(
                                                  _projectServiceMock.Object
                                                 );
            // Act

            var ex = await Assert.ThrowsAsync<BadRequestException>(() => createProjectCommandHandler.Handle(createProjectCommand, default));

            // Assert 

            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.Equal("One or more request arguments was bad!", ex.Message);
        }


        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { new LifecycleMethod(), new User(), new StatusType(), "test", "" },
        new object[] { new LifecycleMethod(), new User(), new StatusType(), "", "test"  },
        new object[] { new LifecycleMethod(), new User(), null, "test", "test"  },
        new object[] { new LifecycleMethod(), null, new StatusType(), "test", "test"  },
        new object[] { null, new User(), new StatusType(), "test", "test"  },
    };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
