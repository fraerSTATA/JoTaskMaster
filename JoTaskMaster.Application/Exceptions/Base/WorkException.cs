using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.Base
{
     public abstract class WorkException: Exception
    {
        public ProblemDetails ProblemDetails { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }

        public WorkException(string message) : base( message) 
        {

        }
       
        
    }
}
