using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Domain.BaseInterfaces
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
