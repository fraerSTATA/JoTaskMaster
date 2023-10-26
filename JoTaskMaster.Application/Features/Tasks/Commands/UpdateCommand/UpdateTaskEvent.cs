using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.Commands.UpdateCommand
{
    public class UpdateTaskEvent : BaseEvent
    {
        public ProjectTask ProjectTask { get;  }

        public UpdateTaskEvent (ProjectTask projectTask) => ProjectTask = projectTask;
    }
}
