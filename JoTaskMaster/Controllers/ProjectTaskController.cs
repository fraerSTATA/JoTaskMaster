using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Features.Tasks.Queries;
using JoTaskMaster.Shared;
using JoTaskMaster.Application.Features.Tasks.Queries.GetAllProjectTasksQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTaskById;
using JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTaskByStatus;
using JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTaskBySubTask;
using JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTasksByProject;
using JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTasksByUser;
using JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand;
using JoTaskMaster.Application.Features.Tasks.Commands.DeleteCommand;

namespace JoTaskMaster.Api.Controllers
{
    public class ProjectTaskController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectTaskController(IMediator mediator) => _mediator = mediator;

        #region Get methods

        [HttpGet("Get_All_Project_Tasks")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetAllProjectTasks()
        {
            return await _mediator.Send(new GetAllProjectTasksQuery());
        }

        [HttpGet("Get_Project_Task_By_Id/projectTaskId:int")]
        public async Task<ActionResult<Result<TaskDTO>>> GetProjectTaskById(int projectTaskId)
        {
            return await _mediator.Send(new GetProjectTaskByIdQuery(projectTaskId));
        }

        [HttpGet("Get_Project_Task_By_Status/statusTypeId:int")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetProjectTaskByStatus(int statusTypeId)
        {
            return await _mediator.Send(new GetProjectTasksByStatusQuery(statusTypeId));
        }

        [HttpGet("Get_Project_Task_By_SubTask/subTaskId:int")]
        public async Task<ActionResult<Result<TaskDTO>>> GetProjectTaskBySubTask(int subTaskId)
        {
            return await _mediator.Send(new GetProjectTaskBySubTaskQuery(subTaskId));
        }

        [HttpGet("Get_Project_Task_By_Project/projectId:int")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetProjectTaskByProject(int projectId)
        {
            return await _mediator.Send(new GetProjectTaskByProjectQuery(projectId));
        }

        [HttpGet("Get_Project_Task_By_User/userId:int")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetProjectTasksByUser(int userId)
        {
            return await _mediator.Send(new GetProjectTaskByUserQuery(userId));
        }
        #endregion

        #region Post methods
        [HttpPost("Create_Project_Task")]
        public async Task<ActionResult<Result<int>>> CreateProjectTask(CreateTaskCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put methods
        #endregion

        #region Delete methods

        [HttpDelete("Delete_Project_Task")]
        public async Task<ActionResult<Result<int>>> DeleteProjectTask(DeleteTaskCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
    }
}
