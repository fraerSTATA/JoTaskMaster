using JoTaskMaster.Application.Exceptions.Base;
using JoTaskMaster.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.CommandExceptions.UpdateCommandExceptions
{
    public class UpdateRequestException : WorkException

    {

        public UpdateRequestException(string message = "Update failed") : base(message)
        {
            StatusCode = HttpStatusCode.BadRequest;
            ProblemDetails = new()
            {
                Status = (int)StatusCode,
                Title = "Update failed",
                Type = "UpdateFailed",
                Detail = "Update entity failed, one or more fields incorrect"
            };
        }

        public UpdateRequestException(ProblemDetails pd, string message = "Update failed") : base(message)
        {
            StatusCode = HttpStatusCode.BadRequest;
            ProblemDetails = pd;
        }
    }
}
