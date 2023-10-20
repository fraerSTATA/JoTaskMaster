using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Application.Exceptions.NotFound;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain.Entities;
using JoTaskMaster.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Companies.Commands.DeleteCommand
{
    public record DeleteCompanyCommand : IRequest<Result<int>>, IMapFrom<User>
    {
        public int Id { get; set; }
        public DeleteCompanyCommand(int id) => Id = id;
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
            var com = _companyService.GetCompanyById(request.Id);
            if(com != null)
            {             
                await _companyService.DeleteCompanyAsync(com.Id);
                return await Result<int>.SuccessAsync("Company Deleted");
             }
            else
            {
                throw new CompanyNotFoundException($"Company with id = {request.Id} Not Found");
            }

        }
    }


}
