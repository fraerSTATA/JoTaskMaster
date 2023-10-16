using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JoTaskMaster.Application.Features.Users;
using JoTaskMaster.Application.Features.Users.Queries.GetAllUsers;
using JoTaskMaster.Application.Features.Users.Queries;
using JoTaskMaster.Application.Features.Users.Queries.GetUserById;
using JoTaskMaster.Application.Features.Users.Commands.CreateCommand;

namespace JoTaskMaster.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

       /// <summary>
       /// Get user by id query
       /// </summary>
       /// <param name="id">Represent user id</param>
       /// <returns>Result of query</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Result<UserDTO>>> GetUserById(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));

        }

        /// <summary>
        /// Get all users query
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]

        public async Task<ActionResult<Result<List<GetAllUsersDTO>>>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
    
}
