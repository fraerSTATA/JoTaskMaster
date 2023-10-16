using JoTaskMaster.Application.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

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
                    WorkException workException = (WorkException)ex;
                    await ProblemResponseAsync(workException.StatusCode, workException.ProblemDetails, context);
                }
                else
                {
                    ProblemDetails pb = new()
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = "Server Error",
                        Title = "Server Error",
                        Detail = "An internal server has occurred"
                    };
                    await ProblemResponseAsync(HttpStatusCode.InternalServerError, pb, context);
                }

            }
        }
    }
}
