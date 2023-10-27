using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery : IRequest<Result<ProjectDTO>>
    {
        public int Id { get; set; }
        public GetProjectByIdQuery(int id) => Id = id;
       
    }

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Result<ProjectDTO>> 
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public GetProjectByIdQueryHandler(IMapper mapper, IProjectService projectService)
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        public async Task<Result<ProjectDTO>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var proj = _projectService.GetProjectById(request.Id)
                       ?? throw new ProjectNotFoundException();

            return await Result<ProjectDTO>.SuccessAsync(_mapper.Map<ProjectDTO>(proj));
        }
    }

}

