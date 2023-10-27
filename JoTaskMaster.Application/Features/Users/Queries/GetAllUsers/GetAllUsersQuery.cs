using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;


namespace JoTaskMaster.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<Result<List<GetAllUsersDTO>>> { }  
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<List<GetAllUsersDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _userService = service;
        }
        public async Task<Result<List<GetAllUsersDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync()
                              ?? throw new UserNotFoundException();

            return await Result<List<GetAllUsersDTO>>.SuccessAsync(_mapper.Map<List<GetAllUsersDTO>>(users));

        }
    }
}
