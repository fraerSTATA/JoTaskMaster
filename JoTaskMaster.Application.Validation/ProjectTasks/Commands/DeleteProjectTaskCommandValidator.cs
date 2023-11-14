using FluentValidation;
using JoTaskMaster.Application.Features.Tasks.Commands.DeleteCommand;
using JoTaskMaster.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Validation.ProjectTasks.Commands
{
   public sealed class DeleteProjectTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteProjectTaskCommandValidator(IProjectTaskService sv) 
        {
            RuleFor(p => p.Id).MustAsync(async(taskId, _) =>
            {
                return null != await sv.GetProjectTaskByIdAsync(taskId);

            }).WithMessage("ProjectTask dont exists!");
        }
    }
}
