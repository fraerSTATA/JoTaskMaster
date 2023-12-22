using JoTaskMaster.Application.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using FluentValidation;
using System.ComponentModel;


namespace JoTaskMaster.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> loggerFactory) => _logger = loggerFactory;
      
        private async Task ProblemResponseAsync(HttpStatusCode code, ProblemDetails problem,HttpContext context)
        {
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";
         await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (ex is  WorkException)
                {
                    var workException = (WorkException)ex;
                    await ProblemResponseAsync(workException.StatusCode, workException.ProblemDetails, context);
                }

                else if(ex is FluentValidation.ValidationException)
                {
                    var valException = (FluentValidation.ValidationException)ex;
                    var pb = new ProblemDetails()
                    {
                        Type = "Valiadation Exception",
                        Title = "Validation Erorrs",
                        Status = (int)HttpStatusCode.BadRequest,
                        Detail = valException.Message,
                        
                    };
                    await ProblemResponseAsync(HttpStatusCode.BadRequest, pb, context);
                }
                else
                {
                    ProblemDetails pb = new()
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = "Server Error",
                        Title = "Server Error",
                        Detail = ex.Message
                    };
                    await ProblemResponseAsync(HttpStatusCode.InternalServerError, pb, context);
                }

            }
        }
    }
}
