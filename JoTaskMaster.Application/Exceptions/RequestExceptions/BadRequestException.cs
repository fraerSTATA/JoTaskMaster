using JoTaskMaster.Application.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.RequestExceptions
{
    public class BadRequestException : WorkException
    {       
        
        public BadRequestException(string message = "Bad Request"
            ) : base(message)

        {
            StatusCode = HttpStatusCode.BadRequest;
            ProblemDetails = new()
            {
                Status = (int)StatusCode,
                Title = Message,
                Type = "Server Error",
                Detail = "Wrong url data in request"
            };
        }
    }
}
