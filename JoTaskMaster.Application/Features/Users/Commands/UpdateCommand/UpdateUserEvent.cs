using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Users.Commands.UpdateCommand
{
   public class UpdateUserEvent : BaseEvent
    {
        public User User { get; }
        public UpdateUserEvent(User user) => User = user;
    }
}
