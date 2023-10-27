using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class ProjectTask : BaseAuditableEntity
{
    public int ProjectTaskId { get; set; }

    public DateTime? TaskDate { get; set; }

    public DateTime? TastEndDate { get; set; }

    public int TaskManagerId { get; set; }

    public string? TaskDescription { get; set; }

    public int TaskStatusId { get; set; }

    public int? SubTaskId { get; set; }

    public virtual ICollection<ProjectTask> InverseSubTask { get; set; } = new List<ProjectTask>();

    public virtual Project ProjectTaskNavigation { get; set; } = null!;

    public virtual ProjectTask? SubTask { get; set; }

    public virtual ICollection<TaskResponse> TaskResponses { get; set; } = new List<TaskResponse>();

    public virtual StatusType TaskStatus { get; set; } = null!;

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
