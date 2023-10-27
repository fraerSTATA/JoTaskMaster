using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;

namespace JoTaskMaster.Application.Features.Companies.Commands.DeleteCommand
{
    public record DeleteCompanyCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public DeleteCompanyCommand(int id) => Id = id;
        
        public DeleteCompanyCommand(Company company) => Id = company.Id;
    }

    internal class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Result<int>>
    {
        private readonly ICompanyService _companyService;

        public DeleteCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public async Task<Result<int>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var com = _companyService.GetCompanyById(request.Id)
                      ?? throw new CompanyNotFoundException($"Company with id = {request.Id} Not Found");

            await _companyService.DeleteCompanyAsync(com.Id);
            com.AddDomainEvent(new DeleteCompanyEvent(com));
            return await Result<int>.SuccessAsync("Company Deleted");
            
               
            

        }
    }


}
