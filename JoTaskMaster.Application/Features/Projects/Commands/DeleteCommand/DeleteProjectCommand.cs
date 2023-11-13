using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand
{
    public record DeleteProjectCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeleteProjectCommand(int id) => Id = id;
        public DeleteProjectCommand(Project project) => Id = project.Id;
    }

    internal class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Result<int>>
    {
        private readonly IProjectService _projectService;
        public DeleteProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public async Task<Result<int>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var proj = _projectService.GetProjectById(request.Id)
                       ?? throw new ProjectNotFoundException($"Project with id = {request.Id} doesn't exist!");

            await _projectService.DeleteProjectAsync(proj.Id);
            return await Result<int>.SuccessAsync(proj.Id, "Project deleted");

        }
    }
}
