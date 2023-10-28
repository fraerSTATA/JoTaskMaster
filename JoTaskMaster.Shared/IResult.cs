using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Shared
{
   public interface IResult 
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }

        //List<ValidationResult> ValidationErrors { get; set; }

        Exception Exception { get; set; }

        int Code { get; set; }
    }
}
