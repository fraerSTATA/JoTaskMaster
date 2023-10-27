using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand
{
    public record CreateSubTaskCommand : IRequest<Result<int>>, IMapFrom<ProjectTask>
    {
        public int ProjectTaskId { get; set; }

        public DateTime? TaskDate { get; set; }

        public DateTime? TastEndDate { get; set; }

        public int TaskManagerId { get; set; }

        public string? TaskDescription { get; set; }

        public int TaskStatusId { get; set; }

        public int? SubTask { get; set; }
    }

    public class CreateSubTaskCommandHandler : IRequestHandler<CreateSubTaskCommand, Result<int>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IUserService _userService;
        private readonly IStatusTypeService _statusTypeService;
        private readonly IProjectService _projectService;

        public CreateSubTaskCommandHandler(IProjectTaskService projectTaskService, IUserService userService, IStatusTypeService statusTypeService, IProjectService projectService)
        {
            _projectTaskService = projectTaskService;
            _userService = userService;
            _statusTypeService = statusTypeService;
            _projectService = projectService;
        }
        public async Task<Result<int>> Handle(CreateSubTaskCommand request, CancellationToken cancellationToken)
        {
            if (_projectService.GetProjectById(request.ProjectTaskId) == null
               || _userService.GetUserById(request.TaskManagerId) == null
               || _statusTypeService.GetStatusTypeById(request.TaskStatusId) == null
               || request.SubTask == null)
            {
                throw new BadRequestException("One or more bad arguments in request!");
            }
            var projTask = new ProjectTask
            {
                TaskStatusId = request.TaskStatusId,
                TaskDate = request.TaskDate,
                TaskDescription = request.TaskDescription,
                ProjectTaskId = request.ProjectTaskId,
                TastEndDate = request.TaskDate,
                TaskManagerId = request.TaskManagerId,
                SubTaskId = request.SubTask,
                CreatedDate = DateTime.Now
            };
            _projectTaskService.CreateProjectTask(projTask);
            projTask.AddDomainEvent(new CreateTaskEvent(projTask));
            return await Result<int>.SuccessAsync(projTask.Id, "SubProjectTaskCreated");
        }
    }
}
