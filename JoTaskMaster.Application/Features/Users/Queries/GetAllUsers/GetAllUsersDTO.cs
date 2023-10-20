 using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersDTO : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
       
        public int CompanyId { get; set; }       
        public int  RoleId { get; set; }

    }
}
