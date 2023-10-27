using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Projects.DTO
{
    public class ProjectDTO : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string ProjectName { get; set; } = null!;

        public int ProjectModelId { get; set; }

        public int StatusId { get; set; }

        public string Description { get; set; } = null!;

        public int UserManagerId { get; set; }
    }
}
