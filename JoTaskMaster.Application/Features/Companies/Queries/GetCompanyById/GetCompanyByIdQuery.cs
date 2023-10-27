using AutoMapper;
using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Features.Companies.DTO;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Companies.Queries
{
    public record GetCompanyByIdQuery : IRequest<Result<CompanyDTO>>
    {
        public int Id { get; set; }
        public GetCompanyByIdQuery(int id) => Id = id;
    }

    internal class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Result<CompanyDTO>>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public GetCompanyByIdQueryHandler(ICompanyService companyService, IMapper mapper) 
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        public async Task<Result<CompanyDTO>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyService.GetCompanyByIdAsync(request.Id)
                                ?? throw new CompanyNotFoundException($"Company with id = {request.Id} NOT FOUND!");

            return await Result<CompanyDTO>.SuccessAsync(_mapper.Map<CompanyDTO>(company));
        }
    }
}
