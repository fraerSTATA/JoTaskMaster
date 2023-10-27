using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.Commands.DeleteCommand
{
    public record DeleteTaskCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public DeleteTaskCommand(int id) => Id = id;

        public DeleteTaskCommand(ProjectTask pt) => Id = pt.Id;
    }


    internal class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<int>>
    {
        private readonly IProjectTaskService _projectTaskService;

        public DeleteTaskCommandHandler(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }
        public async Task<Result<int>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var projTask = _projectTaskService.GetProjectTaskById(request.Id)
                ?? throw new ProjectTaskNotFoundException($"ProjectTask with Id = {request.Id} Not Found!");
            await _projectTaskService.DeleteProjectTaskAsync(projTask.Id);
            projTask.AddDomainEvent(new DeleteTaskEvent(projTask));
            return await Result<int>.SuccessAsync(request.Id, "Project task deleted!");

        }
    }
}
