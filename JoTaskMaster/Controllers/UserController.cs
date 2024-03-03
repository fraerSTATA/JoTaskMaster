using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JoTaskMaster.Application.Features.Users;
using JoTaskMaster.Application.Features.Users.Queries.GetAllUsers;
using JoTaskMaster.Application.Features.Users.Queries;
using JoTaskMaster.Application.Features.Users.Queries.GetUserById;
using JoTaskMaster.Application.Features.Users.Commands.CreateCommand;
using JoTaskMaster.Application.Features.Users.Commands.DeleteCommand;
using JoTaskMaster.Application.Features.Users.Commands.UpdateCommand;

namespace JoTaskMaster.Api.Controllers
{
    public class UserController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get methods

        /// <summary>
        /// Get user by id query
        /// </summary>
        /// <param name="userId">Represent user id</param>
        /// <returns>User dto</returns>
        /// <response code="200">Returns user dto</response>
        /// <response code="404">User not found</response>
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<Result<UserDTO>>> GetUserById(int userId)
        {
            return await _mediator.Send(new GetUserByIdQuery(userId));

        }

        /// <summary>
        /// Get all users query
        /// </summary>
        /// <returns>List of user dto</returns>
        /// <response code="200">Returns list of user dto</response>
        /// <response code="404">Users not found</response>
        [HttpGet("")]
        public async Task<ActionResult<Result<List<GetAllUsersDTO>>>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }
        
        #endregion
        
        #region Post methods
        
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="command">Represent create user command</param>
        /// <returns>List of user dto</returns>
        /// <response code="200">Returns updated user id</response>\
        /// <response code="400">Bad arguments</response>
        /// <response code="404">User not found</response>
        [HttpPost("")]
        public async Task<ActionResult<Result<int>>> Create([FromBody] CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Delete methods
        /// <summary>
        /// Delete user query
        /// </summary>
        /// <returns>Deleted user id</returns>
        /// <response code="200">Returns deleted user id</response>\
        /// <response code="404">User not found</response>
        [HttpDelete("")]
        public async Task<ActionResult<Result<int>>> Delete([FromBody] DeleteUserCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Put methods
        /// <summary>
        /// Update User query
        /// </summary>
        /// <returns>Updated user id</returns>
        /// <response code="200">Returns updated user id</response>\
        /// <response code="404">User not found</response>
        [HttpPut("")]
        public async Task<ActionResult<Result<int>>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion
    }

}
