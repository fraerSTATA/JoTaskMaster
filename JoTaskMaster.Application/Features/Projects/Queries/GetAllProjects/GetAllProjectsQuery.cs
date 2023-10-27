using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Shared;
using MediatR;


namespace JoTaskMaster.Application.Features.Projects.Queries.GetAllProjects
{
    public record GetAllProjectsQuery : IRequest<Result<List<ProjectDTO>>> { }
    
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
            var projects = _projectService.GetAllProjects()
                           ?? throw new ProjectNotFoundException();

            return await Result<List<ProjectDTO>>.SuccessAsync(_mappeer.Map<List<ProjectDTO>>(projects));
        }
    }
}
