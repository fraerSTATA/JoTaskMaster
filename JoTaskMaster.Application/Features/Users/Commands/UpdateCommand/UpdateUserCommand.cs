using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.Base;
using JoTaskMaster.Application.Exceptions.CommandExceptions;
using JoTaskMaster.Application.Exceptions.CommandExceptions.UpdateCommandExceptions;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Users.Queries;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Commands.UpdateCommand
{
    public record UpdateUserCommand :  IRequest<Result<int>>, IMapFrom<User>
    {

        public int Id { get; set; }
        public string Nickname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

    }

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<int>>
    {
        private readonly IUserService _userService;
        private readonly ISecurityService _securityService;

        public UpdateUserCommandHandler(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        public async Task<Result<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Email == null || request.Password == null || request.UserName == null 
                || request.UserName == null || request.Nickname == null)
            {
                throw new UpdateRequestException();
            }
            var user =  await _userService.GetUserByIdAsync(request.Id);
            if(user  != null)
            {
               
                user.UserSurname = request.UserSurname;
                user.UserName = request.UserName;
                user.Password = _securityService.Hashing(request.Password);
                user.UserCompanyId = request.CompanyId;
                user.UserRoleId = request.RoleId;
                user.Nickname = request.Nickname;
                user.Email = request.Email; 
                user.UpdateDate = DateTime.Now;
                await _userService.UpdateUserAsync(user);
                return await Result<int>.SuccessAsync(request.Id, "User updated");
            }
            else
            {
                throw new UserNotFoundException("User with id = {request.Id} Not Found!");
            }
            
        }
    }
}
