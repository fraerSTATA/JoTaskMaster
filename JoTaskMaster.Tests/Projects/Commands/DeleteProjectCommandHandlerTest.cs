using Azure.Core;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.Projects.Commands
{
    public class DeleteProjectCommandHandlerTest
    {
       private readonly Mock<IProjectService> _projectServiceMock;

        public DeleteProjectCommandHandlerTest()
        {
            _projectServiceMock = new Mock<IProjectService>();
        }

        [Fact]
        public async void Delete_Project_Success()
        {
            //Arrange 

            var proj = new Project();
            var deleteProjectCommand = new DeleteProjectCommand(1);
            _projectServiceMock.Setup(p => p.GetProjectById(It.IsAny<int>())).Returns(proj);
            _projectServiceMock.Setup(p => p.DeleteProjectAsync(It.IsAny<int>()));
            var DpCH = new DeleteProjectCommandHandler(_projectServiceMock.Object);

            //Act

            var result = await DpCH.Handle(deleteProjectCommand, default);

            //Assert

            Assert.True(result.Succeeded);
            Assert.Equal("Project deleted", result.Messages.First());
        }

        [Fact]
        public async void Delete_Project_Throws_Proejct_Not_Found_Exception()
        {
            //Arrange 

            DeleteProjectCommand deleteProjectCommand = new DeleteProjectCommand(1);
            _projectServiceMock.Setup(p => p.GetProjectById(It.IsAny<int>())).Returns(() => null);
            _projectServiceMock.Setup(p => p.DeleteProjectAsync(It.IsAny<int>()));
            DeleteProjectCommandHandler DpCH = new (_projectServiceMock.Object);

            //Act

            var ex =  await Assert.ThrowsAsync<ProjectNotFoundException>(() =>
                DpCH.Handle(deleteProjectCommand, default));

            //Assert

            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
            Assert.Equal($"Project with id = {deleteProjectCommand.Id} doesn't exist!", ex.Message);
        }
    }
}
