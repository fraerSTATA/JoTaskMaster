using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTaskBySubTask
{
    public record GetProjectTaskBySubTaskQuery : IRequest<Result<TaskDTO>> 
    {
        public int Id { get; set; }
        public GetProjectTaskBySubTaskQuery(ProjectTask pt) => Id = pt.Id;
        public GetProjectTaskBySubTaskQuery(int id) => Id = id;
    }

    internal class GetProjectTaskBySubTaskQueryHandler : IRequestHandler<GetProjectTaskBySubTaskQuery, Result<TaskDTO>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;
        public GetProjectTaskBySubTaskQueryHandler(IProjectTaskService projectTaskService, IMapper mapper)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;

        }
        public async Task<Result<TaskDTO>> Handle(GetProjectTaskBySubTaskQuery request, CancellationToken cancellationToken)
        {
            var subT = await _projectTaskService.GetProjectTaskByIdAsync(request.Id)
                             ?? throw new ProjectTaskNotFoundException("SubTask not found");
            if(subT.SubTaskId == null)
            {
                throw new BadRequestException("This is not subTask");
            }
            var projT = await _projectTaskService.GetProjectTaskBySubTaskAsync(subT);
            return await Result<TaskDTO>.SuccessAsync(_mapper.Map<TaskDTO>(projT));
        }
    }
}
