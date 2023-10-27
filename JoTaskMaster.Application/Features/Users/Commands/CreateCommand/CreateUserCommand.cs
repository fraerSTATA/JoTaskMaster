using JoTaskMaster.Domain.Entities;
using MediatR;
using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Shared;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Application.Exceptions.CommandExceptions.CreateCommandException;

namespace JoTaskMaster.Application.Features.Users.Commands.CreateCommand
{
    public record CreateUserCommand : IRequest<Result<int>>, IMapFrom<User>
    {
        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string Nickname { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int UserCompanyId { get; set; }

        public int UserRoleId { get; set; }

    }

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
    {
        private readonly IUserService _userService = null!;
        private readonly ISecurityService _securityService = null!;

        public CreateUserCommandHandler(IUserService userService,ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }
        public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(_userService.GetUserByEmail(request.Email) != null)
            {
                throw new AlreadyExistsException("User with this email has already exists!");
            }
            var user = new User
            {
                Nickname = request.Nickname,
                Email = request.Email,
                UserName = request.UserName,
                Password = _securityService.Hashing(request.Password),
                UserSurname = request.UserSurname,
                UserCompanyId = request.UserCompanyId,
                UserRoleId = request.UserRoleId,
                RegistryDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            await _userService.CreateUserAsync(user);
            user.AddDomainEvent(new UserCreatedEvent(user));
            return await Result<int>.SuccessAsync(user.Id, "User created");
        }
    }
}
