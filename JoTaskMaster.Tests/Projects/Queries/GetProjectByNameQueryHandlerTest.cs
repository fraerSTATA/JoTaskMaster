using AutoMapper;
using Azure.Core;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectById;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByName;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.Projects.Queries
{
    public class GetProjectByNameQueryHandlerTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProjectService> _projectServiceMock;

        public GetProjectByNameQueryHandlerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new Mock<IProjectService>();
        }

        [Fact]
        public async void Project_By_Name_Query_Handler_Throws_Project_Not_Found_Exception()
        {
            //Arrange

            var proj = new Project() { Id = 1 };

            ProjectDTO projectDTO = new() { Id = 1 };

            var getProjectByNameQuery = new GetProjectByNameQuery("test");

            _projectServiceMock.Setup(x => x.GetProjectByNameAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.Map<ProjectDTO>(It.IsAny<Project>())).Returns(projectDTO);

            var getProjectByNameQueryHandler = new GetProjectByNameQueryHandler(
                                                  _projectServiceMock.Object,
                                                  _mapperMock.Object);

            //Act

            var ex = await Assert.ThrowsAsync<ProjectNotFoundException>(() => 
                                             getProjectByNameQueryHandler.Handle(getProjectByNameQuery, default));

            //Assert

            Assert.NotNull(ex);
            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
            Assert.Equal($"Project with name = {getProjectByNameQuery.Name}", ex.Message);

        }


        [Fact]
        public async void Project_By_Name_Query_Handler_Success()
        {
            //Arrange

            var proj = new Project() { Id = 1 };

            ProjectDTO projectDTO = new() { Id = 1 };

            var getProjectByNameQuery = new GetProjectByNameQuery("test");

            _projectServiceMock.Setup(x => x.GetProjectByNameAsync(It.IsAny<string>())).ReturnsAsync(proj);
            _mapperMock.Setup(x => x.Map<ProjectDTO>(It.IsAny<Project>())).Returns(projectDTO);

            var getProjectByNameQueryHandler = new GetProjectByNameQueryHandler(
                                                  _projectServiceMock.Object,
                                                  _mapperMock.Object);

            //Act            
            var result = await  getProjectByNameQueryHandler.Handle(getProjectByNameQuery, default);

            //Assert

            Assert.NotNull(result);

            Assert.True(result.Succeeded);

        }

    }
}
