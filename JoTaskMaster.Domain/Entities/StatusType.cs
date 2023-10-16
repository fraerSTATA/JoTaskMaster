using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class StatusType : BaseAuditableEntity
{

    public string StatusName { get; set; } = null!;

    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
