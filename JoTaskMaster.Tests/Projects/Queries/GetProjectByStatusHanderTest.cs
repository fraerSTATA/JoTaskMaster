using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByManager;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByStatus;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.Projects.Queries
{
    public class GetProjectByStatusHanderTest
    {

        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProjectService> _projectServiceMock;
        private readonly Mock<IStatusTypeService> _statusTypeServiceMock;

        public GetProjectByStatusHanderTest()
        {
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new Mock<IProjectService>();
            _statusTypeServiceMock = new Mock<IStatusTypeService>();
        }

        [Fact]
        public async void Get_Project_By_Status_Success()
        {

            //Arrange

            var proj = new List<Project>() { new Project { Id = 1 }, new Project { Id = 2 } };
            var status = new StatusType() { Id = 1 };
            var projectDTO = new List<ProjectDTO>() { new ProjectDTO { Id = 1 }, new ProjectDTO { Id = 2 } };

            var getProjectByStatusQuery = new GetProjectByStatusQuery(status.Id);

            _projectServiceMock.Setup(x => x.GetProjectsByStatusAsync(It.IsAny<StatusType>())).ReturnsAsync(proj);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTO);
            _statusTypeServiceMock.Setup(u => u.GetStatusTypeByIdAsync(It.IsAny<int>())).ReturnsAsync(status);

            var getProjectByStatusQueryHandler = new GetProjectByStatusQueryHandler(
                                                  _projectServiceMock.Object,
                                                  _mapperMock.Object,
                                                  _statusTypeServiceMock.Object
                                                 );

            //Act            
            var result = await getProjectByStatusQueryHandler.Handle(getProjectByStatusQuery, default);

            //Assert

            Assert.NotNull(result);

            Assert.True(result.Succeeded);
        }


        [Fact]
        public async void Get_Project_By_Status_Throw_Status_Type_Not_Found_Exception()
        {

            //Arrange

            var proj = new List<Project>() { new Project { Id = 1 }, new Project { Id = 2 } };
            var status = new StatusType() { Id = 1 };
            var projectDTO = new List<ProjectDTO>() { new ProjectDTO { Id = 1 }, new ProjectDTO { Id = 2 } };

            var getProjectByStatusQuery = new GetProjectByStatusQuery(status.Id);

            _projectServiceMock.Setup(x => x.GetProjectsByStatusAsync(It.IsAny<StatusType>())).ReturnsAsync(proj);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTO);
            _statusTypeServiceMock.Setup(u => u.GetStatusTypeByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            var getProjectByStatusQueryHandler = new GetProjectByStatusQueryHandler(
                                                  _projectServiceMock.Object,
                                                  _mapperMock.Object,
                                                  _statusTypeServiceMock.Object
                                                 );

            //Act            
            var ex = await Assert.ThrowsAsync<StatusTypeNotFoundException>(() =>
                                            getProjectByStatusQueryHandler.Handle(getProjectByStatusQuery, default));

            //Assert

            Assert.NotNull(ex);
            Assert.Equal("StatusType not found in server Database", ex.Message);
            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
        }


        [Fact]
        public async void Get_Project_By_Status_Throw_Project_Not_Found_Exception()
        {

            //Arrange

            var proj = new List<Project>() { new Project { Id = 1 }, new Project { Id = 2 } };
            var status = new StatusType() { Id = 1 };
            var projectDTO = new List<ProjectDTO>() { new ProjectDTO { Id = 1 }, new ProjectDTO { Id = 2 } };

            var getProjectByStatusQuery = new GetProjectByStatusQuery(status.Id);

            _projectServiceMock.Setup(x => x.GetProjectsByStatusAsync(It.IsAny<StatusType>())).ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTO);
            _statusTypeServiceMock.Setup(u => u.GetStatusTypeByIdAsync(It.IsAny<int>())).ReturnsAsync(status);

            var getProjectByStatusQueryHandler = new GetProjectByStatusQueryHandler(
                                                  _projectServiceMock.Object,
                                                  _mapperMock.Object,
                                                  _statusTypeServiceMock.Object
                                                 );

            //Act            
            var ex = await Assert.ThrowsAsync<ProjectNotFoundException>(() =>
                                            getProjectByStatusQueryHandler.Handle(getProjectByStatusQuery, default));

            //Assert

            Assert.NotNull(ex);
            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
        }
    }
}
