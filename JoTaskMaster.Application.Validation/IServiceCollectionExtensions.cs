using FluentValidation;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using Microsoft.Extensions.DependencyInjection;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Validation.Projects.Commands;
using JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand;
using JoTaskMaster.Application.Validation.ProjectTasks.Commands;
using JoTaskMaster.Application.Features.Tasks.Commands.DeleteCommand;

namespace JoTaskMaster.Application.Validation
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplicationValidationLayer(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateProjectCommand>, CreateProjectCommandValidator>();
            services.AddScoped<IValidator<DeleteProjectCommand>, DeleteProjectCommandValidator>();
            services.AddScoped<IValidator<CreateTaskCommand>, CreateProjectTaskCommandValidator>();
            services.AddScoped<IValidator<DeleteTaskCommand>, DeleteProjectTaskCommandValidator>();

        }
    }
    
}
