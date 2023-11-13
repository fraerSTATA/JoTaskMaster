using FluentValidation;
using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;
using System.Runtime.CompilerServices;
using JoTaskMaster.Application;

[assembly: InternalsVisibleTo("JoTaskMaster.Tests")]
namespace JoTaskMaster.Application.Features.Projects.Commands.CreateCommand
{

    public record CreateProjectCommand : IRequest<Result<int>>, IMapFrom<Project>
    {
        public string ProjectName { get; set; } = null!;

        public int ProjectModelId { get; set; }

        public int StatusId { get; set; }

        public string Description { get; set; } = null!;

        public int UserManagerId { get; set; }
    }

    internal class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<int>>
    {
        private readonly IProjectService _projectService;
     
        public CreateProjectCommandHandler(IProjectService project)
        {
            _projectService = project;
           
        }

        public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            
            var proj = new Project
            {
                ProjectModelId = request.ProjectModelId,
                ProjectName = request.ProjectName,
                StatusId = request.StatusId,
                Description = request.Description,
                UserManagerId = request.UserManagerId,
                CreatedDate = DateTime.Now
            };

            _projectService.CreateProject(proj);
            proj.AddDomainEvent(new CreateProjectEvent(proj));
            return await Result<int>.SuccessAsync(proj.Id, "Project created");

        }
    }
}
