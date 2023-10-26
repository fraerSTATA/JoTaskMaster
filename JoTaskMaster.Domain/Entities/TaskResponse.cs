using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class TaskResponse : BaseAuditableEntity
{
    public int TaskId { get; set; }

    public int UserId { get; set; }

    public string? TaskMassage { get; set; }

    public virtual ProjectTask Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
