using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectById;
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
    public class GetProjectByIdHandlerTest
    {

        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProjectService> _projectServiceMock;

        public GetProjectByIdHandlerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new Mock<IProjectService>();
        }

        [Fact]
        public async void Get_Project_By_Id_Query_Handler_Success()
        {
            //Arrange

            var proj = new Project() { Id = 1};

            ProjectDTO projectDTO = new() { Id = 1 };

            var getProjectByIdQuery = new GetProjectByIdQuery(1);

            _projectServiceMock.Setup(x => x.GetProjectByIdAsync(It.IsAny<int>())).ReturnsAsync(proj);
            _mapperMock.Setup(x => x.Map<ProjectDTO>(It.IsAny<Project>())).Returns(projectDTO);

            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(_mapperMock.Object, _projectServiceMock.Object);

            //Act

            var result = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, default);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(projectDTO, result.Data);
            Assert.True(result.Succeeded);

        }

        [Fact]
        public async void Get_Project_By_Id_Query_Handler_Throws_Project_Not_Found_Exception()
        {
            //Arrange

            var proj = new Project() { Id = 1 };

            ProjectDTO projectDTO = new() { Id = 1 };

            var getProjectByIdQuery = new GetProjectByIdQuery(1);

            _projectServiceMock.Setup(x => x.GetProjectByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.Map<ProjectDTO>(It.IsAny<Project>())).Returns(projectDTO);

            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(_mapperMock.Object, _projectServiceMock.Object);

            //Act

            var ex = await Assert.ThrowsAsync<ProjectNotFoundException>(() =>
                                                getProjectByIdQueryHandler.Handle(getProjectByIdQuery, default));

            //Assert

             Assert.NotNull(ex);
            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
            Assert.Equal("Project not found in server Database", ex.Message);

        }
    }
}
