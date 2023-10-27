using JoTaskMaster.Application.Mappers;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdDTO : IMapFrom<User>
    {
        public string Nickname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserSurname { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
    }
}
