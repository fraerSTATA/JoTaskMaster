using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetProjectByStatus
{  
    
        public record GetProjectByStatusQuery : IRequest<Result<ProjectDTO>>
        {
            public int Id  { get; set; }
            public GetProjectByStatusQuery(StatusType status) => Id = status.Id;
            public GetProjectByStatusQuery(int id) => Id = id;
        }

        internal class GetProjectByNameQueryHandler : IRequestHandler<GetProjectByStatusQuery, Result<ProjectDTO>>
        {
            private readonly IProjectService _projectService;
            private readonly IMapper _mapper;
            private readonly IStatusTypeService _statusTypeService;

            public GetProjectByNameQueryHandler(IProjectService projectService, IMapper mapper, IStatusTypeService statusTypeService)
            {
                _projectService = projectService;
                _mapper = mapper;
                _statusTypeService = statusTypeService;
            }

            public async Task<Result<ProjectDTO>> Handle(GetProjectByStatusQuery request, CancellationToken cancellationToken)
            {
                var status =  await _statusTypeService.GetStatusTypeByIdAsync(request.Id)
                              ?? throw new StatusTypeNotFoundException();
                var proj   =  await _projectService.GetProjectsByStatusAsync(status) 
                              ?? throw new ProjectNotFoundException($"Projects with status = {status.StatusName} doesnt exists ");

                return await Result<ProjectDTO>.SuccessAsync(_mapper.Map<ProjectDTO>(proj));
            }
        }
    
}
