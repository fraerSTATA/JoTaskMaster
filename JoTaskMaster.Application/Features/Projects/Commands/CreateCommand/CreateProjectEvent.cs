using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Projects.Commands.CreateCommand
{
    public class CreateProjectEvent : BaseEvent
    {
        public Project Project { get; }

        public CreateProjectEvent(Project project) => Project = project;
    }
}
