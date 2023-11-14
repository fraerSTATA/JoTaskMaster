using FluentValidation;
using JoTaskMaster.Application.Behaviors;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JoTaskMaster.Application;
using System.Runtime.CompilerServices;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Validation.Projects.Commands;
using JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand;
using JoTaskMaster.Application.Validation.ProjectTasks.Commands;
using JoTaskMaster.Application.Features.Tasks.Commands.DeleteCommand;

namespace JoTaskMaster.Application.Validation
{
    public static class IServiceCollectionExtensions
    {

        public static void AddAplicationValidationLayer(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateProjectCommand>, CreateProjectCommandValidator>();
            services.AddScoped<IValidator<DeleteProjectCommand>, DeletePropjectCommandValidator>();
            services.AddScoped<IValidator<CreateTaskCommand>, CreateProjectTaskCommandValidator>();
            services.AddScoped<IValidator<DeleteTaskCommand>, DeleteProjectTaskCommandValidator>();

        }
    }
    
}
