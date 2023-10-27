using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Companies.Commands.CreateCommand
{
    public class CreateCompanyEvent : BaseEvent
    {
        public Company Company { get;}
        public CreateCompanyEvent( Company company)  => Company = company;
    }
}
