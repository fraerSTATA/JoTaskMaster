using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Users.Queries.GetAllUsers;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects
{
    public record  GetAllProjectsQuery : IRequest<Result<List<ProjectDTO>>>
    {
    }

    internal class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, Result<List<ProjectDTO>>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mappeer;
        public GetAllProjectsQueryHandler(IProjectService projectService, IMapper mapper) 
        { 
                _projectService = projectService;
                 _mappeer = mapper;
        }
        public async Task<Result<List<ProjectDTO>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {            
            var projects = _projectService.GetAllProjects();
            if(projects == null)
            {
                throw new ProjectNotFoundException();
            }
            return await Result<List<ProjectDTO>>.SuccessAsync(_mappeer.Map<List<ProjectDTO>>(projects));
        }
    }
}
