using AutoMapper;
using JoTaskMaster.Application.Features.Companies.DTO;
using JoTaskMaster.Application.Features.Users.Queries.GetAllUsers;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Companies.Queries.GetAllCompanies
{
    public record GetAllCompaniesQuery : IRequest<Result<List<CompanyDTO>?>>
    {
    }

    internal class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, Result<List<CompanyDTO>?>>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public GetAllCompaniesQueryHandler(ICompanyService companyService, IMapper mapper)
        {
            _mapper = mapper;
            _companyService = companyService;
        }
                                                           
        public async Task<Result<List<CompanyDTO>?>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
           var companies =  await _companyService.GetAllCompaniesAsync();
           return await Result<List<CompanyDTO>?>.SuccessAsync(_mapper.Map<List<CompanyDTO>?>(companies));
        }
    }
}
