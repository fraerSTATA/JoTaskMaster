using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;


namespace JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTasksByProject
{
    public record GetProjectTaskByProjectQuery : IRequest<Result<List<TaskDTO>>>
    {
        public int Id { get; set; }
        public GetProjectTaskByProjectQuery(Project pt) => Id = pt.Id;
        public GetProjectTaskByProjectQuery(int id) => Id = id;
    }

    internal class GetProjectTaskByProjectQueryHandler : IRequestHandler<GetProjectTaskByProjectQuery, Result<List<TaskDTO>>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public GetProjectTaskByProjectQueryHandler(IProjectTaskService projectTaskService, IMapper mapper, IProjectService ps)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
            _projectService = ps;
        }
        public async Task<Result<List<TaskDTO>>> Handle(GetProjectTaskByProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectService.GetProjectByIdAsync(request.Id)
                                ?? throw new ProjectNotFoundException("Project not found");           
            var projT  = await _projectTaskService.GetProjectTasksByProjectAsync(project)
                                ?? throw new ProjectTaskNotFoundException($"Project task in project with id = {request.Id} not found");

            return await Result<List<TaskDTO>>.SuccessAsync(_mapper.Map<List<TaskDTO>>(projT));
        }

       
    }
}
