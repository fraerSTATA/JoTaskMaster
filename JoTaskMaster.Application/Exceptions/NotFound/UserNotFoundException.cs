﻿using JoTaskMaster.Application.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.NotFound
{
    public class UserNotFoundException : WorkException
    {
        public UserNotFoundException(string message = "User not found") : base(message ) 
        {
            StatusCode = HttpStatusCode.NotFound;
            ProblemDetails = new ()
            {
                Status = (int) StatusCode,
                Title = Message,
                Type = "Not Found Error",
                Detail = "User not found in Server Database"
            };
        }

        public UserNotFoundException(ProblemDetails pd, string message = "User not found") : base(message)
        {
            StatusCode = HttpStatusCode.NotFound;
            ProblemDetails = pd;
        }
    }
}
