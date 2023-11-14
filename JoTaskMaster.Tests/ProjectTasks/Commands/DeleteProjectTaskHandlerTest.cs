using Azure.Core;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Features.Tasks.Commands.DeleteCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.ProjectTasks.Commands
{
    public class DeleteProjectTaskHandlerTest
    {
        private readonly Mock<IProjectTaskService> _projectTaskServiceMock;

        public DeleteProjectTaskHandlerTest()
        {
            _projectTaskServiceMock = new Mock<IProjectTaskService>();
        }

        [Fact]
        public async void Delete_Project_Task_Success()
        {
            //Arrange 

            var proj = new ProjectTask();
            var deleteTaskCommand = new DeleteTaskCommand(1);
            _projectTaskServiceMock.Setup(p => p.GetProjectTaskById(It.IsAny<int>())).Returns(proj);
            _projectTaskServiceMock.Setup(p => p.DeleteProjectTaskAsync(It.IsAny<int>()));
            var DpCH = new DeleteTaskCommandHandler(_projectTaskServiceMock.Object);

            //Act

            var result = await DpCH.Handle(deleteTaskCommand, default);

            //Assert

            Assert.True(result.Succeeded);
            Assert.Equal("Project task deleted!", result.Messages.First());
        }

     
    }
}
