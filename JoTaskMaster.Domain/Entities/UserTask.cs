using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class UserTask : BaseAuditableEntity
{

    public int TaskUser { get; set; }

    public int UserTaskId { get; set; }

    public virtual ProjectTask Task { get; set; } = null!;

    public virtual User TaskUserNavigation { get; set; } = null!;
}
