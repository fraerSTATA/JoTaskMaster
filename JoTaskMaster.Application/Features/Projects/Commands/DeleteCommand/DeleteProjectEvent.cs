using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand
{
    public class DeleteProjectEvent : BaseEvent
    {
        public Project Project { get; }
        public DeleteProjectEvent(Project project) => Project = project;
    }
}
