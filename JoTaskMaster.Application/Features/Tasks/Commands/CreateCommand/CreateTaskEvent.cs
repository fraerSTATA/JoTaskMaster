using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand
{
    public class CreateTaskEvent : BaseEvent
    {
        public ProjectTask ProjectTask { get; }

        public CreateTaskEvent (ProjectTask projectTask) => ProjectTask = projectTask;

    }
}
