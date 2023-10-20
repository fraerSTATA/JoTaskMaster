using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Companies.DTO
{
    public class CompanyDTO : IMapFrom<Company>
    {
       public int Id { get; set; }
       public string CompanyName { get; set; } = null!;

    }
}
