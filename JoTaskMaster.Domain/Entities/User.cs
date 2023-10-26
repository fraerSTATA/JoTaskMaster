using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class User : BaseAuditableEntity
{
    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserCompanyId { get; set; }

    public int UserRoleId { get; set; }

    public DateTime RegistryDate { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ProjectUser? ProjectUser { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<TaskResponse> TaskResponses { get; set; } = new List<TaskResponse>();

    public virtual Company UserCompany { get; set; } = null!;

    public virtual Role UserRole { get; set; } = null!;

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
