using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class Company : BaseAuditableEntity
{

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
