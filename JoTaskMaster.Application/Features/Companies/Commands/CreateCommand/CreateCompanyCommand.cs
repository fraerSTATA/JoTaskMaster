using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.CommandExceptions.CreateCommandException;
using JoTaskMaster.Application.Exceptions.RequestExceptions;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Companies.Commands.CreateCommand
{
    public record CreateCompanyCommand : IRequest<Result<int>>, IMapFrom<Company>
    {
        public string CompanyName { get; set; } = null!;
    }

    internal class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Result<int>>
    {

        private readonly ICompanyService _companyService;
        
        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        public async Task<Result<int>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {

            if(request.CompanyName == null)
            {
                throw new BadRequestException();
            }
            if (_companyService.GetCompanyByName(request.CompanyName) != null)
            {
                throw new AlreadyExistsException("The company with this name has already existed");
            }
            var company = new Company
            {
                CompanyName = request.CompanyName,
                CreatedDate = DateTime.Now
            };

            await _companyService.CreateCompanyAsync(company);
            company.AddDomainEvent(new CreateCompanyEvent(company));
            return await Result<int>.SuccessAsync(company.Id, "Company created");
           

        }
    }

}
