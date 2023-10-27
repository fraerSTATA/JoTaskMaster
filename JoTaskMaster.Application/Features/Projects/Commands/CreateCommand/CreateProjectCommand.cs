using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly ILifecycleMethodService _lifecycleMethodService;
        private readonly IStatusTypeService _statusTypeService;
        private readonly IUserService _userService;
        public CreateProjectCommandHandler(IProjectService project, ILifecycleMethodService lifecycleMethod, IStatusTypeService statusType, IUserService userService)
        {
            _projectService = project;
            _lifecycleMethodService = lifecycleMethod;
            _statusTypeService = statusType;
            _userService = userService;
        }
 
        public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (request.ProjectName == null
                || _lifecycleMethodService.GetLifecycleMethodById(request.ProjectModelId) == null
                || _statusTypeService.GetStatusTypeById(request.StatusId) == null
                || request.Description == null
                || _userService.GetUserById(request.UserManagerId) == null)             
            {
                throw new BadRequestException("One or more request arguments was bad!");
            }
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
            return await Result<int>.SuccessAsync(proj.Id,"Project created");

        }
    }
}
