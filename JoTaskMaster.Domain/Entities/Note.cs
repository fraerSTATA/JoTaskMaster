using System;
using System.Collections.Generic;

namespace JoTaskMaster.Domain.Entities;

public partial class Note : BaseAuditableEntity
{

    public int ProjectNoteId { get; set; }

    public DateTime NoteDate { get; set; }

    public string NoteMessage { get; set; } = null!;

    public int NoteUserId { get; set; }

    public virtual User NoteUser { get; set; } = null!;

    public virtual Project ProjectNote { get; set; } = null!;
}
