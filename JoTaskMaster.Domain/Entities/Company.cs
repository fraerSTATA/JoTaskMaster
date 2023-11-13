using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class Company : BaseAuditableEntity
{
    /// <summary>
    /// Name of Company
    /// </summary>
    public string CompanyName { get; set; } = null!;

    /// <summary>
    /// Users that work at Company
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
