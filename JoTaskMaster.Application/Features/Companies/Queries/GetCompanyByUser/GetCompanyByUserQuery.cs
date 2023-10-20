using AutoMapper;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Features.Companies.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Companies.Queries.GetCompanyByUser
{
    public record GetCompanyByUserQuery : IRequest<Result<CompanyDTO>>
    {
        public int Id { get; set; }
        public GetCompanyByUserQuery(int id) => Id = id;
        public GetCompanyByUserQuery(User u) => Id = u.Id;
    }
    internal class GetCompanyByUserQueryHandler : IRequestHandler<GetCompanyByUserQuery, Result<CompanyDTO>
    {
        public IUserService _userService;
        public ICompanyService _companyService;
        public IMapper _mapper;

        public GetCompanyByUserQueryHandler(ICompanyService companyService, IMapper mapper, IUserService userService) 
        {
            _userService = userService;
            _companyService = companyService;
            _mapper = mapper;
        }
        public async Task<Result<CompanyDTO>> Handle(GetCompanyByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.Id) ?? throw new BadRequestException();
            var company = await _companyService.GetCompanyByUserAsync(user);
            return await Result<CompanyDTO>.SuccessAsync(_mapper.Map<CompanyDTO>(company));
        }
    }


}
