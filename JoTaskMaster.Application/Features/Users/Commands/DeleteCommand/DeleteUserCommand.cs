
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;


namespace JoTaskMaster.Application.Features.Users.Commands.DeleteCommand
{
     public record DeleteUserCommand : IRequest<Result<int>>
     {
        public int Id { get; set; }
        public DeleteUserCommand(int id) => Id = id;

     }

    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<int>>
    {
        private readonly IUserService _userService;

       public DeleteUserCommandHandler ( IUserService userService )
        {
            _userService = userService;
        }
        public async Task<Result<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync( request.Id )
                             ?? throw new UserNotFoundException($"User with id = {request.Id} not found!");

            await _userService.DeleteUserAsync(request.Id);
            user.AddDomainEvent(new UserDeleteEvent(user));
            return await  Result<int>.SuccessAsync(user.Id, "User deleted");
            
            
               
            
        }
    }
}
