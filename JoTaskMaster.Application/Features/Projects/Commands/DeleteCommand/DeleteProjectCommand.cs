using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand
{
    public record DeleteProjectCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public DeleteProjectCommand (int id) => Id = id;
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
            if(_projectService.GetProjectById(request.Id) == null)
            {
                throw new BadRequestException($"Project with id = {request.Id} doesn't exist!");
            }
             await _projectService.DeleteProjectAsync(request.Id);
             return await Result<int>.SuccessAsync(request.Id, "Project deleted");

        }
    }



}
