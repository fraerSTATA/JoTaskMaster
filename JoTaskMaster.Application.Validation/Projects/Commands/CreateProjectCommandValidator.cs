using FluentValidation;
using JoTaskMaster.Application.Exceptions.Base;
using JoTaskMaster.Application.Features.Projects.Commands.CreateCommand;
using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Validation.Projects.Commands
{
    public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator(IProjectService projectService, ILifecycleMethodService lifecycleMethodService, IStatusTypeService statusTypeService, IUserService userService)
        {
            RuleFor(p => p.ProjectName).MustAsync(async (projectName, _) =>
            {
                var res = await projectService.GetProjectByNameAsync(projectName);
                return res == null;

            }).WithMessage("This project name is already taken");

            RuleFor(u => u.UserManagerId).MustAsync(async (userId, _) =>
            {
                var res = await userService.GetUserByIdAsync(userId);
                return res != null;

            }).WithMessage("The user does'nt exists");

            RuleFor(u => u.ProjectModelId).MustAsync(async (modelId, _) =>
            {
                var res = await lifecycleMethodService.GetLifecycleMethodByIdAsync(modelId);
                return res != null;

            }).WithMessage("The method does'nt exists");

            RuleFor(u => u.StatusId).MustAsync(async (statusId, _) =>
            {
                var res = await statusTypeService.GetStatusTypeByIdAsync(statusId);
                return res != null;

            }).WithMessage("The stastus does'nt exists");
        }


    }
}
