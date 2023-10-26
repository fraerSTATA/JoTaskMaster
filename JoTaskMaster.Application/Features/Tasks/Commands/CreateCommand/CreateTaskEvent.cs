using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand
{
    public class CreateTaskEvent : BaseEvent
    {
        public ProjectTask ProjectTask { get; }

        public CreateTaskEvent (ProjectTask projectTask) => ProjectTask = projectTask;

    }
}
