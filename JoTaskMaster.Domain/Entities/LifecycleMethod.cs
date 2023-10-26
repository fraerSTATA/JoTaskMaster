using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class LifecycleMethod : BaseAuditableEntity
{
    public string MethodName { get; set; } = null!;
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
