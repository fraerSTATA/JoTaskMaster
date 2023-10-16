using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Commands.DeleteCommand
{
    public class UserDeleteEvent : BaseEvent
    {
        User User { get; }

        public UserDeleteEvent(User user)
        {
            User = user;
        }
    }
}
