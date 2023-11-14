using JoTaskMaster.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Behaviors
{
    public class LoggingPipelineBehaviors<TRequest, TResponce> :
        IPipelineBehavior<TRequest, TResponce>
       where TRequest :  IRequest<TResponce>

    {
        private readonly ILogger<LoggingPipelineBehaviors<TRequest, TResponce>> _logger;

        public LoggingPipelineBehaviors(
            ILogger<LoggingPipelineBehaviors<TRequest, TResponce>> logger)
        {
            _logger = logger;
        }
      

        public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
               "Starting request {@RequestName}, {@DateTimeUtc}",
               typeof(TRequest).Name,
               DateTime.UtcNow.ToString());

            var result = await next();

            _logger.LogInformation(
                "Completed request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow.ToString());

            return result;
        }
    }
}
