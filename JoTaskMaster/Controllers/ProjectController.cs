using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectById;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByManager;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByName;
using JoTaskMaster.Application.Features.Projects.Queries.GetProjectByStatus;
using JoTaskMaster.Application.Features.Users.Queries;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JoTaskMaster.Api.Controllers
{
    public class ProjectController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator) => _mediator = mediator;

        #region Get methods

        [HttpGet("Get_All_Projects")]
        public async Task<ActionResult<Result<List<ProjectDTO>>>> GetAllProjects()
        {
            return await _mediator.Send(new GetAllProjectsQuery());
        }

        [HttpGet("Get_Project_By_Id/{projectId:int}")]
        public async Task<ActionResult<Result<ProjectDTO>>> GetProjectById(int projectId)
        {
            return await _mediator.Send(new GetProjectByIdQuery(projectId));
        }


        [HttpGet("Get_Projects_By_User/{userId:int}")]
        public async Task<ActionResult<Result<List<ProjectDTO>>>> GetProjectByUser(int userId)
        {
            return await _mediator.Send(new GetProjectByUserQuery(userId));
        }

        [HttpGet("Get_Projects_By_Name")]
        public async Task<ActionResult<Result<ProjectDTO>>> GetProjectByName(string projectName)
        {
            return await _mediator.Send(new GetProjectByNameQuery(projectName));
        }

        [HttpGet("Get_Projects_By_Status/{statusId:int}")]
        public async Task<ActionResult<Result<List<ProjectDTO>>>> GetProjectByStatus(int statusId)
        {
            return await _mediator.Send(new GetProjectByStatusQuery(statusId));
        }
        #endregion

        #region Post methods

        [HttpPost("Create_Project")]
        public async Task<ActionResult<Result<int>>> CreateProject(CreateProjectCommand command)
        {
            return await _mediator.Send(command);
        }

        #endregion

        #region Delete methods
        [HttpDelete("Delete_Project")]
        public async Task<ActionResult<Result<int>>> DeleteProject(DeleteProjectCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put methods
        #endregion


    }
}
