using AutoMapper;
using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Commands.DeleteCommand
{
     public record DeleteUserCommand : IRequest<Result<int>>, IMapFrom<User>
     {
        public int Id { get; set; }
        public DeleteUserCommand(int id) => Id = id;

     }

    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        DeleteUserCommandHandler (IMapper mapper, IUserService userService )
        {
            _mapper = mapper;
           _userService = userService;
        }
        public async Task<Result<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync( request.Id );
            user.AddDomainEvent(new UserDeleteEvent(user));
            if ( user != null ) 
            {
               return await  Result<int>.SuccessAsync(user.Id, "User deleted");
            }
            else
            {
                throw new UserNotFoundException($"User with id = {request.Id} not found!");
            }
        }
    }
}
