using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Companies.Commands.DeleteCommand
{
    public class DeleteCompanyEvent : BaseEvent
    {
        public Company Company { get; set; }
        public DeleteCompanyEvent(Company company) => Company = company;
    }
}
