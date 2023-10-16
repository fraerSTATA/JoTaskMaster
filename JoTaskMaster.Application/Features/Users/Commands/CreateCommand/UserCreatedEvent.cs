using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Commands.CreateCommand
{
    public class UserCreatedEvent : BaseEvent
    {
        public User User { get;}

        public UserCreatedEvent(User u) => User = u;

    }
}
