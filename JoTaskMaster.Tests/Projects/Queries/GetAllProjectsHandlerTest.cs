using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects;
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
    public class GetAllProjectsHandlerTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProjectService> _projectServiceMock;

        public GetAllProjectsHandlerTest ()
        {
            _mapperMock = new Mock<IMapper> ();
            _projectServiceMock = new Mock<IProjectService> ();
        }

        [Fact]
        public async void Get_All_Projects_Query_Handler_Success()
        {
            //Arrange

            List<Project> projects = new()
            {
                new Project { Id = 1},
                new Project { Id = 2}
            };

            List<ProjectDTO> projectDTOs = new()
            {
                 new ProjectDTO { Id = 1},
                 new ProjectDTO { Id = 2}
            };

            var getAllProjectsQuery = new GetAllProjectsQuery();

            _projectServiceMock.Setup(x => x.GetAllProjectsAsync()).ReturnsAsync(projects);
            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>())).Returns(projectDTOs);

            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(_projectServiceMock.Object, _mapperMock.Object);
            
            //Act

            var result = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, default);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(2, result.Data.Count);
            Assert.True(result.Succeeded);

        }

        [Fact]
        public async void Get_All_Projects_Query_Handler_Throw_Project_Not_Found_Exception()
        {
            //Arrange          
            var getAllProjectsQuery = new GetAllProjectsQuery();

            _mapperMock.Setup(x => x.Map<List<ProjectDTO>>(It.IsAny<List<Project>>()));
            _projectServiceMock.Setup(x => x.GetAllProjectsAsync()).ReturnsAsync(() => null);

            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(_projectServiceMock.Object, _mapperMock.Object);

            //Act

            var ex = await Assert.ThrowsAsync<ProjectNotFoundException>(() => 
                                                    getAllProjectsQueryHandler.Handle(getAllProjectsQuery, default));

            //Assert
            
            Assert.NotNull(ex);
            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
            Assert.Equal("Project not found in server Database", ex.Message);

        }

    }
}
