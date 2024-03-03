using JoTaskMaster.Application.Features.Tasks.DTO;
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
        /// <summary>
        /// Get all projects task
        /// </summary>
        /// <response code="200">Returns List of projectTasks dto</response>
        /// <response code="404">Project tasks not found</response>
        [HttpGet("Get_All_Project_Tasks")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetAllProjectTasks()
        {
            return await _mediator.Send(new GetAllProjectTasksQuery());
        }
        
        /// <summary>
        /// Get all projects task by id
        /// </summary>
        /// <response code="200">Returns projectTask dto</response>
        /// <response code="404">Project tasks not found</response>
        [HttpGet("Get_Project_Task_By_Id/{projectTaskId:int}")]
        public async Task<ActionResult<Result<TaskDTO>>> GetProjectTaskById(int projectTaskId)
        {
            return await _mediator.Send(new GetProjectTaskByIdQuery(projectTaskId));
        }
        
        /// <summary>
        /// Get all projects task by id
        /// </summary>
        /// <response code="200">Returns List of projectTask dto</response>
        /// <response code="404">Project tasks not found</response>
        [HttpGet("Get_Project_Task_By_Status/{statusTypeId:int}")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetProjectTaskByStatus(int statusTypeId)
        {
            return await _mediator.Send(new GetProjectTasksByStatusQuery(statusTypeId));
        }
        
        /// <summary>
        /// Get project task by subTask
        /// </summary>
        /// <response code="200">Returns projectTask dto</response>
        /// <response code="404">Project tasks not found</response>
        [HttpGet("Get_Project_Task_By_SubTask/{subTaskId:int}")]
        public async Task<ActionResult<Result<TaskDTO>>> GetProjectTaskBySubTask(int subTaskId)
        {
            return await _mediator.Send(new GetProjectTaskBySubTaskQuery(subTaskId));
        }
        
        /// <summary>
        /// Get project tasks by project
        /// </summary>
        /// <response code="200">Returns list of projectTask dto</response>
        /// <response code="404">Project tasks not found</response>
        [HttpGet("Get_Project_Task_By_Project/{projectId:int}")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetProjectTaskByProject(int projectId)
        {
            return await _mediator.Send(new GetProjectTaskByProjectQuery(projectId));
        }
        
        /// <summary>
        /// Get project task by user
        /// </summary>
        /// <response code="200">Returns list of user projectTask dto</response>
        /// <response code="404">Project tasks not found</response>
        [HttpGet("Get_Project_Task_By_User/{userId:int}")]
        public async Task<ActionResult<Result<List<TaskDTO>>>> GetProjectTasksByUser(int userId)
        {
            return await _mediator.Send(new GetProjectTaskByUserQuery(userId));
        }
        #endregion
        
        /// <summary>
        /// Create project task
        /// </summary>
        /// <response code="200">Returns created project task id</response>
        /// <response code="400">Bad Request</response>
        #region Post methods
        [HttpPost("")]
        public async Task<ActionResult<Result<int>>> CreateProjectTask([FromBody]CreateTaskCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put methods
        #endregion

        #region Delete methods
        
        /// <summary>
        /// Delete project task
        /// </summary>
        /// <response code="200">Returns deleted project task id</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Project task not found</response>
        [HttpDelete("")]
        public async Task<ActionResult<Result<int>>> DeleteProjectTask([FromBody] DeleteTaskCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
    }
}
