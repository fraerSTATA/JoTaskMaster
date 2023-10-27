using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTaskById
{
    public record GetProjectTaskByIdQuery : IRequest<Result<TaskDTO>>
    {
        public int Id { get; set; }
        public GetProjectTaskByIdQuery(int id) => Id = id;
        public GetProjectTaskByIdQuery(ProjectTask task) => Id = task.Id;
    }

    internal class GetAllProjectTasksQueryHandler : IRequestHandler<GetProjectTaskByIdQuery, Result<TaskDTO>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IMapper _mapper;
        public GetAllProjectTasksQueryHandler(IProjectTaskService projectTaskService, IMapper mapper)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
        }
        public async Task<Result<TaskDTO>> Handle(GetProjectTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _projectTaskService.GetProjectTaskByIdAsync(request.Id)
                              ?? throw new ProjectTaskNotFoundException($"ProjectTask with id = {request.Id} not found!");

            return await Result<TaskDTO>.SuccessAsync(_mapper.Map<TaskDTO>(tasks));
        }

       
    }
}
