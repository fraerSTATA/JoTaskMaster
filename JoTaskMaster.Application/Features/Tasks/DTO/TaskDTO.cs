using JoTaskMaster.Application.Common.Mapping;
using JoTaskMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Features.Tasks.DTO
{
    public class TaskDTO : IMapFrom<ProjectTask>
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }

        public DateTime? TaskDate { get; set; }

        public DateTime? TastEndDate { get; set; }

        public int TaskManagerId { get; set; }

        public string? TaskDescription { get; set; }

        public int TaskStatusId { get; set; }

        public int? SubTaskId { get; set; }

        public int TaskPriorityId { get; set; }
    }
}
