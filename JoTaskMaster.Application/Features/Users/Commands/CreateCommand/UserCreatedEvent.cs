using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Users.Commands.CreateCommand
{
    public class UserCreatedEvent : BaseEvent
    {
        public User User { get;}

        public UserCreatedEvent(User u) => User = u;

    }
}
