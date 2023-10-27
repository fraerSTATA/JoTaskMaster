using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Domain.Entities;

namespace JoTaskMaster.Application.Features.Companies.DTO
{
    public class CompanyDTO : IMapFrom<Company>
    {
       public int Id { get; set; }
       public string CompanyName { get; set; } = null!;

    }
}
