using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.Queries.GetAllProjectTasksQuery
{
    public record GetAllProjectTasksQuery : IRequest<Result<List<TaskDTO>>>
    {
    }

    internal class GetAllProjectTasksQueryHandler : IRequestHandler<GetAllProjectTasksQuery, Result<List<TaskDTO>>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;
        public GetAllProjectTasksQueryHandler(IProjectTaskService projectTaskService, IMapper mapper)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
        }
        public async Task<Result<List<TaskDTO>>> Handle(GetAllProjectTasksQuery request, CancellationToken cancellationToken)
        {

            var tasks = await _projectTaskService.GetAllProjectTasksAsync() 
            ?? throw new ProjectTaskNotFoundException("ProjectTasks not found!");
            return await Result<List<TaskDTO>>.SuccessAsync(_mapper.Map<List<TaskDTO>>(tasks));
        }
    }
}
