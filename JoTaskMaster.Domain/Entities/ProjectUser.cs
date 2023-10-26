using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class ProjectUser : BaseAuditableEntity
{
    public int ProjectId { get; set; }

    public int UserId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User UserProject { get; set; } = null!;
}
