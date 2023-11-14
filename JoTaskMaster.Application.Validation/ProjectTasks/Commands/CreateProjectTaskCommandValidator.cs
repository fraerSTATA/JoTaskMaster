using FluentValidation;
using JoTaskMaster.Application.Features.Tasks.Commands.CreateCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Validation.ProjectTasks.Commands
{
    public sealed class CreateProjectTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public  CreateProjectTaskCommandValidator( IUserService userService, IStatusTypeService statusTypeService, IProjectService projectService)
        {
            RuleFor(x => x.TaskManagerId).MustAsync(async (userId, _) => 
            {
                return null != await userService.GetUserByIdAsync(userId);
            }).WithMessage("User don't exists!");

            RuleFor(x => x.TaskStatusId).MustAsync(async (statusId, _) =>
            {
                return null != await statusTypeService.GetStatusTypeByIdAsync(statusId);
            }).WithMessage("StatusType don't exists!");

            RuleFor(x => x.ProjectTaskId).MustAsync(async (projectId, _) =>
            {
                return null != await projectService.GetProjectByIdAsync(projectId);
            }).WithMessage("Project don't exists!");

            RuleFor(x => x.TaskDescription)
                .MinimumLength(10).WithMessage("Name should be more than 10  symbols")
                .MaximumLength(100).WithMessage("Name should be less than 100  symbols");

            RuleFor(x => x.TastEndDate)
             .GreaterThan(DateTime.Now.AddDays(1)).WithMessage("End date need be more than 1 day of actual date");
           

        }
    }
}
