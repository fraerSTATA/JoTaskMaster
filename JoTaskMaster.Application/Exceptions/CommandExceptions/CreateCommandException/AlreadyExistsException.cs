using JoTaskMaster.Application.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.CommandExceptions.CreateCommandException
{
    public class AlreadyExistsException : WorkException
    {
        public AlreadyExistsException(string message ="The entity has already existed") : base(message)
        {
            StatusCode = HttpStatusCode.Created;
            ProblemDetails = new()
            {
                Status = (int)StatusCode,
                Title = "Create failed",
                Type = "Create Error",
                Detail = "Create failed because one or more unique values already exists"
            };
        }

        public AlreadyExistsException(ProblemDetails pd, string message) : base(message)
        {
            StatusCode = HttpStatusCode.Created;
            ProblemDetails = pd;
        }
    }
}
