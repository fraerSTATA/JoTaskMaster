using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class Role : BaseAuditableEntity
{

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
