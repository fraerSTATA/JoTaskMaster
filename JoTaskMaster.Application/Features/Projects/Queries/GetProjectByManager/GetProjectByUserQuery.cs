using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Features.Users.Queries;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetProjectByManager
{
    public record GetProjectByUserQuery : IRequest<Result<List<ProjectDTO>>>
    {
        public int Id { get; set; }
        public GetProjectByUserQuery(UserDTO user) => Id = user.Id;
        public GetProjectByUserQuery(int id) => Id = id;
    }

    internal class GetProjectByUserQueryHandler : IRequestHandler<GetProjectByUserQuery, Result<List<ProjectDTO>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IProjectService _projectService;

        public GetProjectByUserQueryHandler(IMapper mapper, IProjectService projectService, IUserService userService )
        {
            _mapper = mapper;
            _projectService = projectService;
            _userService = userService;            
        }

        public async Task<Result<List<ProjectDTO>>> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
        {
           var user =  await _userService.GetUserByIdAsync(request.Id)
                        ?? throw new UserNotFoundException();
            var proj = await _projectService.GetProjectByUserAsync(user)
                        ?? throw new ProjectNotFoundException($"Project with user id ={request.Id} not found");

            return await Result<List<ProjectDTO>>.SuccessAsync(_mapper.Map<List<ProjectDTO>>(proj));
        }
    }
}
