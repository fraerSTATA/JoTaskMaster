using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Users.Queries.GetUserById
{
    public record class GetUserByIdQuery : IRequest<Result<UserDTO>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery() { }
        public GetUserByIdQuery(int id) => Id = id;

    }
  

    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDTO>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Result<UserDTO>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user =  await _userService.GetUserByIdAsync(query.Id)         
                              ?? throw new UserNotFoundException($"User with id = {query.Id} Not Found");

            return await Result<UserDTO>.SuccessAsync(_mapper.Map<UserDTO>(user));
            
        }

     
    }
}
