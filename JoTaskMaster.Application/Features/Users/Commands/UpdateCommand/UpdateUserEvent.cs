using JoTaskMaster.Domain;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Commands.UpdateCommand
{
   public class UpdateUserEvent : BaseEvent
    {
        public User User { get; }
        public UpdateUserEvent(User user) => User = user;
    }
}
