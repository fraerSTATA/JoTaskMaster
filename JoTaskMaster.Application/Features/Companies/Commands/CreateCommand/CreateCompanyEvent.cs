using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Companies.Commands.CreateCommand
{
    public class CreateCompanyEvent : BaseEvent
    {
        public Company Company { get;}
        public CreateCompanyEvent( Company company)  => Company = company;
    }
}
