using AutoMapper;
using Azure.Core;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByManager;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByName;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Tests.Projects.Queries
{
    public class GetProjectByUserQueryHandlerTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProjectService> _projectServiceMock;
        private readonly Mock<IUserService> _userServiceMock;

        public GetProjectByUserQueryHandlerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _projectServiceMock = new Mock<IProjectService>();
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async void Project_By_User_Query_Handler_Success()
        {
            //Arrange

            var proj = new List<Project>() {  new Project { Id = 1}, new Project { Id = 2 } };
            var user = new User() { Id = 1 };
            var projectDTO = new List<ProjectDTO>() { new ProjectDTO { Id = 1 }, new ProjectDTO { Id = 2 } };

            var getProjectByUserQuery = new GetProjectByUserQuery(user.Id);

            _projectServiceMock.Setup(x => x.GetProjectByUserAsync(It.IsAny<User>())).ReturnsAsync(proj);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTO);
            _userServiceMock.Setup(u => u.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            var getProjectByUserQueryHandler = new GetProjectByUserQueryHandler(
                                                  _mapperMock.Object,
                                                  _projectServiceMock.Object,
                                                  _userServiceMock.Object
                                                 );

            //Act            
            var result = await getProjectByUserQueryHandler.Handle(getProjectByUserQuery, default);

            //Assert

            Assert.NotNull(result);

            Assert.True(result.Succeeded);

        }

        [Fact]
        public async void Project_By_User_Query_Handler_Throws_User_Not_Found_Exception()
        {
            //Arrange

            var proj = new List<Project>() { new Project { Id = 1 }, new Project { Id = 2 } };
            var user = new User() { Id = 1 };
            var projectDTO = new List<ProjectDTO>() { new ProjectDTO { Id = 1 }, new ProjectDTO { Id = 2 } };

            var getProjectByUserQuery = new GetProjectByUserQuery(user.Id);

            _projectServiceMock.Setup(x => x.GetProjectByUserAsync(It.IsAny<User>())).ReturnsAsync(proj);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTO);
            _userServiceMock.Setup(u => u.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            var getProjectByUserQueryHandler = new GetProjectByUserQueryHandler(
                                                  _mapperMock.Object,
                                                  _projectServiceMock.Object,
                                                  _userServiceMock.Object
                                                 );

            //Act            
            var ex = await Assert.ThrowsAsync<UserNotFoundException>(() =>
                             getProjectByUserQueryHandler.Handle(getProjectByUserQuery, default));

            //Assert

            Assert.Equal(HttpStatusCode.NotFound , ex.StatusCode);

            Assert.Equal("User not found",ex.Message);

        }

        [Fact]
        public async void Project_By_User_Query_Handler_Throws_Project_Not_Found_Exception()
        {
            //Arrange

            var proj = new List<Project>() { new Project { Id = 1 }, new Project { Id = 2 } };
            var user = new User() { Id = 1 };
            var projectDTO = new List<ProjectDTO>() { new ProjectDTO { Id = 1 }, new ProjectDTO { Id = 2 } };

            var getProjectByUserQuery = new GetProjectByUserQuery(user.Id);

            _projectServiceMock.Setup(x => x.GetProjectByUserAsync(It.IsAny<User>())).ReturnsAsync(() => null);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTO);
            _userServiceMock.Setup(u => u.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            var getProjectByUserQueryHandler = new GetProjectByUserQueryHandler(
                                                  _mapperMock.Object,
                                                  _projectServiceMock.Object,
                                                  _userServiceMock.Object
                                                 );

            //Act            
            var ex = await Assert.ThrowsAsync<ProjectNotFoundException>(() =>
                             getProjectByUserQueryHandler.Handle(getProjectByUserQuery, default));

            //Assert

            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);

            Assert.Equal($"Project with user id ={getProjectByUserQuery.Id} not found", ex.Message);

        }
    }
}
