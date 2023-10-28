using FluentValidation;
using JoTaskMaster.Application.Behaviors;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application
{
    public static class IServiceCollectionExtenstions
    {
        public static void AddAplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediator();
            services.AddValidators();
            services.AddLogger();

        }

        public static void AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(
                Assembly.GetExecutingAssembly());

        public static void AddMediator(this IServiceCollection services) =>
                services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly()));

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private static void AddLogger(this IServiceCollection services)
        {
            services.AddScoped(
                typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviors<,>));
        }

    }
    
}



 