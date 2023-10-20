using JoTaskMaster.Application.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.NotFound
{
    public class CompanyNotFoundException : WorkException
    {
        public CompanyNotFoundException(string message = "Company not found in server Database") : base(message)
        {
            StatusCode = HttpStatusCode.NotFound;
            ProblemDetails = new()
            {
                Status = (int)StatusCode,
                Title = "Company not found",
                Type = "Not Found Error",
                Detail = message
            };
        }

        public CompanyNotFoundException(ProblemDetails pd, string message = "Company not found in server Database") : base(message)
        {
            StatusCode = HttpStatusCode.NotFound;
            ProblemDetails = pd;
        }
    }
}
