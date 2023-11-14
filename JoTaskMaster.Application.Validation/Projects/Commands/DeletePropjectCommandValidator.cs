using FluentValidation;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Validation.Projects.Commands
{
    public sealed class DeletePropjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeletePropjectCommandValidator(IProjectService projectService)
        {
            RuleFor(p => p.Id).MustAsync(async (projectId, _) =>
            {
                return null != await projectService.GetProjectByIdAsync(projectId);
            }).WithMessage("Project with this id doesn't exists");
        }
    }
}
