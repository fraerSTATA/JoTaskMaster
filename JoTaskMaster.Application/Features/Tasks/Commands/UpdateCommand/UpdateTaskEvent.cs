using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Tasks.Commands.UpdateCommand
{
    public class UpdateTaskEvent : BaseEvent
    {
        public ProjectTask ProjectTask { get;  }

        public UpdateTaskEvent (ProjectTask projectTask) => ProjectTask = projectTask;
    }
}
