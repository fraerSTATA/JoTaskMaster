using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Tasks.DTO;
using JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTasksByProject;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;


namespace JoTaskMaster.Application.Features.Tasks.Queries.GetProjectTasksByUser
{
    internal class GetProjectTaskByUser : IRequest<Result<List<TaskDTO>>>
    {
         {
        public int Id { get; set; }

        public GetProjectTaskByUser(User user) => Id = user.Id;
        public GetProjectTaskByUser(int id) => Id = id;
    }

    internal class GetProjectTaskByUserQueryHandler : IRequestHandler<GetProjectTaskByProjectQuery, Result<List<TaskDTO>>>
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetProjectTaskByUserQueryHandler(IProjectTaskService projectTaskService, IMapper mapper, IUserService ps)
        {
            _projectTaskService = projectTaskService;
            _mapper = mapper;
            _userService = ps;
        }
        public async Task<Result<List<TaskDTO>>> Handle(GetProjectTaskByProjectQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.Id)
                ?? throw new ProjectNotFoundException($"User with id = {request.Id} not found");

            var projT = await _projectTaskService.GetProjectTasksByUserAsync(user)
                ?? throw new ProjectTaskNotFoundException($"Project task was maden by user with id = {request.Id} not found");
            return await Result<List<TaskDTO>>.SuccessAsync(_mapper.Map<List<TaskDTO>>(projT));
        }


    }
}
}
