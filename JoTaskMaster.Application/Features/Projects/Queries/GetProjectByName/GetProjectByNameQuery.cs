using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetProjectByName
{
    public record GetProjectByNameQuery : IRequest<Result<ProjectDTO>>
    {
        public string Name { get; set; }
        public GetProjectByNameQuery(string name) => Name = name; 
    }

    internal class GetProjectByNameQueryHandler : IRequestHandler<GetProjectByNameQuery, Result<ProjectDTO>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public GetProjectByNameQueryHandler(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<Result<ProjectDTO>> Handle(GetProjectByNameQuery request, CancellationToken cancellationToken)
        {
            var proj = await _projectService.GetProjectByNameAsync(request.Name)
                       ?? throw new ProjectNotFoundException($"Project with name = {request.Name}");

            return await Result<ProjectDTO>.SuccessAsync(_mapper.Map<ProjectDTO>(proj));  
        }
    }
}
