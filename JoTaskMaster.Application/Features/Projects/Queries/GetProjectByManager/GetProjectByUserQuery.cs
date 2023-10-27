using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Projects.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Projects.Queries.GetProjectByManager
{
    public record GetProjectByUserQuery : IRequest<Result<ProjectDTO>>
    {
        public int Id { get; set; }
        public GetProjectByUserQuery(User user) => Id = user.Id;

        public GetProjectByUserQuery(int id) => Id = id;
    }

    internal class GetProjectByUserQueryHandler : IRequestHandler<GetProjectByUserQuery, Result<ProjectDTO>>
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

        public async Task<Result<ProjectDTO>> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
        {
            var user =  await _userService.GetUserByIdAsync(request.Id)
                        ?? throw new UserNotFoundException();
            var proj =  await _projectService.GetProjectByUserAsync(user)
                        ?? throw new ProjectNotFoundException($"User with id ={request.Id} not found");

            return await Result<ProjectDTO>.SuccessAsync(_mapper.Map<ProjectDTO>(proj));
        }
    }
}
