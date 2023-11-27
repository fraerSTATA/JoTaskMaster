using Azure;
using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JoTaskMaster.Shared;

namespace JoTaskMaster.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>      
       where TResponse : IResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
    
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);

            var val = _validators
            .Select(async x => await x.ValidateAsync(context))
            .SelectMany( x => x.Result.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

            string? errors = null;
            foreach ( var error in val )
            {
                string temp = "";
                foreach(var message in error.Value)
                {
                    temp += (message + "\r\n");
                }
                errors += $"{error.Key} - {temp} \r\n";
            }

            if (!errors.IsNullOrEmpty())
            {
                throw new FluentValidation.ValidationException(errors);
            }
            return await next();
        }
    }
}
