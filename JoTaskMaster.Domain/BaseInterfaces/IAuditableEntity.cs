using JoTaskMaster.Domain.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Domain
{
    public interface IAuditableEntity : IEntity
    { 
          
        DateTime? CreatedDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
