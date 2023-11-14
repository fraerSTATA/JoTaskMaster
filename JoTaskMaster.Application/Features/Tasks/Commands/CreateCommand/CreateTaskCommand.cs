using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand
{
    public record CreateTaskCommand : IRequest<Result<int>>, IMapFrom<ProjectTask>
    {
        public int ProjectTaskId { get; set; }

        public DateTime? TaskDate { get; set; }

        public DateTime? TastEndDate { get; set; }

        public int TaskManagerId { get; set; }

        public string? TaskDescription { get; set; }

        public int TaskStatusId { get; set; }


    }

    internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<int>>
    {
        private readonly IProjectTaskService _projectTaskService;
       

        public CreateTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
          
        }
        public async Task<Result<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
        
            var projTask = new ProjectTask
            {
                TaskStatusId = request.TaskStatusId,
                TaskDate = request.TaskDate,
                TaskDescription = request.TaskDescription,
                ProjectTaskId = request.ProjectTaskId,
                TastEndDate = request.TaskDate,
                TaskManagerId = request.TaskManagerId,
                CreatedDate = DateTime.Now
            };
            _projectTaskService.CreateProjectTask(projTask);
            projTask.AddDomainEvent(new CreateTaskEvent(projTask));
            return await Result<int>.SuccessAsync(projTask.Id, "ProjectTaskCreated");                                                                                                                           
        }
    }
}
