using AutoMapper;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Companies.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Companies.Queries.GetCompanyByName
{
    public record GetCompanyByNameQuery : IRequest<Result<CompanyDTO>>
    {
        public string Name { get; set; }
        public GetCompanyByNameQuery (string name) => Name = name;
    }

    internal class GetCompanyByNameQueryHandler : IRequestHandler<GetCompanyByNameQuery, Result<CompanyDTO>>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public GetCompanyByNameQueryHandler( ICompanyService companyService, IMapper mapper) 
        {
            _companyService = companyService;
            _mapper = mapper;
        }


        public async Task<Result<CompanyDTO>> Handle(GetCompanyByNameQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyService.GetCompanyByNameAsync(request.Name);
            if (company == null)
            {
                throw new CompanyNotFoundException($"Company with name ={request.Name } not found!");
            }
            return await Result<CompanyDTO>.SuccessAsync(_mapper.Map<CompanyDTO>(company));
          
        }
    }
}
