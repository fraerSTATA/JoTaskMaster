using JoTaskMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Shared;
using JoTaskMaster.Infrastructure.Services;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using Microsoft.Identity.Client;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Application.Exceptions.RequestExceptions;

namespace JoTaskMaster.Application.Features.Users.Commands.CreateCommand
{
    public record CreateUserCommand : IRequest<Result<int>>, IMapFrom<User>
    {

        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int UserCompanyId { get; set; }

        public int UserRoleId { get; set; }

        public DateTime RegistryDate { get; set; }

    }

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
    {
        private readonly IMapper _mapper = null!;
        private readonly IUserService _userService = null!;
        private readonly ISecurityService _securityService = null!;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper, ISecurityService securityService)
        {
            _mapper = mapper;
            _userService = userService;
            _securityService = securityService;
        }



        public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {


            var user = new User
            {
                UserName = request.UserName,
                Password = _securityService.Hashing(request.Password),
                UserSurname = request.UserSurname,
                UserCompanyId = request.UserCompanyId,
                UserRoleId = request.UserRoleId,
                RegistryDate = request.RegistryDate
            };

            await _userService.CreateUserAsync(user);
            user.AddDomainEvent(new UserCreatedEvent(user));
            return await Result<int>.SuccessAsync(user.Id, "User created");
        }
    }



}
