using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class ProjectFile : BaseAuditableEntity
{
    public string FileName { get; set; }

    public string FileURL{ get; set; }
}
