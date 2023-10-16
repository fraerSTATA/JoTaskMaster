using AutoMapper;
using AutoMapper.QueryableExtensions;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<Result<List<GetAllUsersDTO>>> 
    {
       
    
    }

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
              var users = await _userService.GetAllUsersAsync();

              return await Result<List<GetAllUsersDTO>>.SuccessAsync(_mapper.Map<List<GetAllUsersDTO>>(users));

        }
    }
}
