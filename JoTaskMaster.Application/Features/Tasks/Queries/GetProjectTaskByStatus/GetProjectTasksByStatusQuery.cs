using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTaskByStatus
{
    public record GetProjectTasksByStatusQuery : IRequest<Result<List<TaskDTO>>>
    {
        public int Id { get; set; }
        public GetProjectTasksByStatusQuery(int id ) => Id= id;
        public GetProjectTasksByStatusQuery(StatusType status) => Id = status.Id; 
    }
    internal class GetProjectTasksByStatusHandler : IRequestHandler<GetProjectTasksByStatusQuery, Result<List<TaskDTO>>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;
        private readonly IStatusTypeService _statusTypeService;
        public GetProjectTasksByStatusHandler(IProjectTaskService projectTaskService, IMapper mapper, IStatusTypeService statusTypeService)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
            _statusTypeService = statusTypeService;
        }
        public async Task<Result<List<TaskDTO>>> Handle(GetProjectTasksByStatusQuery request, CancellationToken cancellationToken)
        {
            var statusType = await _statusTypeService.GetStatusTypeByIdAsync(request.Id)
                                   ?? throw new StatusTypeNotFoundException();
            var projTask   = await _projectTaskService.GetProjectTasksByStatusAsync(statusType)
                                   ?? throw new ProjectTaskNotFoundException($"Project task with status = {statusType.StatusName} Not Found! ");

            return await Result<List<TaskDTO>>.SuccessAsync(_mapper.Map<List<TaskDTO>>(projTask));
        }
    }
}
