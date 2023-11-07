using Azure.Core;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.ProjectTasks.Commands
{
    public class CreateProjectTaskHandlerTest
    {
        private readonly Mock<IProjectTaskService> _projectTaskServiceMock;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IStatusTypeService> _statusTypeServiceMock;
        private readonly Mock<IProjectService> _projectServiceMock;

        public CreateProjectTaskHandlerTest()
        {
            _projectTaskServiceMock = new Mock<IProjectTaskService>();
            _userServiceMock = new Mock<IUserService>();
            _statusTypeServiceMock = new Mock<IStatusTypeService>();
            _projectServiceMock = new Mock<IProjectService>();
        }

        [Fact]
        public async void Create_Project_Task_Handler_Success()
        {

            //Arrange
            var proj = new Project() { Id = 1 };
            var user = new User() { Id = 1 };
            var status = new StatusType() { Id = 1 };
            var command = new CreateTaskCommand()
            {
                TaskStatusId = 1,
                TaskDate = DateTime.Now,
                TaskDescription = "test",
                ProjectTaskId = 1,
                TastEndDate = DateTime.Now,
                TaskManagerId = 1,
            };

            _projectServiceMock.Setup(x => x.GetProjectById(It.IsAny<int>())).Returns(proj);
            _userServiceMock.Setup(u => u.GetUserById(It.IsAny<int>())).Returns(user);
            _statusTypeServiceMock.Setup(s => s.GetStatusTypeById(It.IsAny<int>())).Returns(status);

            _projectTaskServiceMock.Setup(p => p.CreateProjectTask(It.IsAny<ProjectTask>()));

            var createTaskCommandHandler = new CreateTaskCommandHandler(_projectTaskServiceMock.Object,
                                                                        _userServiceMock.Object,
                                                                        _statusTypeServiceMock.Object,
                                                                        _projectServiceMock.Object);

            //Act
            var res =  await createTaskCommandHandler.Handle(command, default);
            //Assert
            Assert.NotNull(res);
            Assert.True(res.Succeeded);
            Assert.Equal("ProjectTaskCreated", res.Messages.First());
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public async void Create_Project_Task_Handler_Throws_Bad_Argument_Exception(Project proj, User user, StatusType status)
        {

            //Arrange
           
            var command = new CreateTaskCommand()
            {
                TaskStatusId = 1,
                TaskDate = DateTime.Now,
                TaskDescription = "test",
                ProjectTaskId = 1,
                TastEndDate = DateTime.Now,
                TaskManagerId = 1,
            };

            _projectServiceMock.Setup(x => x.GetProjectById(It.IsAny<int>())).Returns(proj);
            _userServiceMock.Setup(u => u.GetUserById(It.IsAny<int>())).Returns(user);
            _statusTypeServiceMock.Setup(s => s.GetStatusTypeById(It.IsAny<int>())).Returns(status);

            _projectTaskServiceMock.Setup(p => p.CreateProjectTask(It.IsAny<ProjectTask>()));

            var createTaskCommandHandler = new CreateTaskCommandHandler(_projectTaskServiceMock.Object,
                                                                        _userServiceMock.Object,
                                                                        _statusTypeServiceMock.Object,
                                                                        _projectServiceMock.Object);

            //Act
            var ex = await Assert.ThrowsAsync<BadRequestException>(() => createTaskCommandHandler.Handle(command, default));
            //Assert
            Assert.NotNull(ex);
            Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.Equal("One or more bad arguments in request!", ex.Message);
        }

        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { null, new User(), new StatusType() },
            new object[] { new Project(), null, new StatusType()},
            new object[] {  new Project(), new User(), null, },

        };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
