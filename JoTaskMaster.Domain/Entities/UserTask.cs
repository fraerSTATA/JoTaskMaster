using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class UserTask : BaseAuditableEntity
{

    public int ProjectTaskId { get; set; }

    public int UserTaskId { get; set; }

    public virtual ProjectTask ProjectTask { get; set; } = null!;

    public virtual User UserTaskNavigation { get; set; } = null!;
}
