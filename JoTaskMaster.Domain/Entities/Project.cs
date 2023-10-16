using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class Project : BaseAuditableEntity
{

    public string ProjectName { get; set; } = null!;

    public int ProjectModelId { get; set; }

    public DateTime CreationDate { get; set; }

    public int StatusId { get; set; }

    public string Description { get; set; } = null!;

    public int UserManagerId { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual LifecycleMethod ProjectModel { get; set; } = null!;

    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    public virtual StatusType Status { get; set; } = null!;

    public virtual User UserManager { get; set; } = null!;
}
