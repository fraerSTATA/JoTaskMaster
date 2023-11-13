using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetProjectByStatus
{

    public record GetProjectByStatusQuery : IRequest<Result<List<ProjectDTO>>>
    {
        public int Id { get; set; }
        public GetProjectByStatusQuery(StatusType status) => Id = status.Id;
        public GetProjectByStatusQuery(int id) => Id = id;
    }

    internal class GetProjectByStatusQueryHandler : IRequestHandler<GetProjectByStatusQuery, Result<List<ProjectDTO>>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly IStatusTypeService _statusTypeService;

        public GetProjectByStatusQueryHandler(IProjectService projectService, IMapper mapper, IStatusTypeService statusTypeService)
        {
            _projectService = projectService;
            _mapper = mapper;
            _statusTypeService = statusTypeService;
        }

        public async Task<Result<List<ProjectDTO>>> Handle(GetProjectByStatusQuery request, CancellationToken cancellationToken)
        {
            var status = await _statusTypeService.GetStatusTypeByIdAsync(request.Id)
                          ?? throw new StatusTypeNotFoundException();
            var proj = await _projectService.GetProjectsByStatusAsync(status)
                          ?? throw new ProjectNotFoundException($"Projects with status = {status.StatusName} doesnt exists ");

            return await Result<List<ProjectDTO>>.SuccessAsync(_mapper.Map<List<ProjectDTO>>(proj));
        }
    }

}
