using FluentValidation;
using JoTaskMaster.Application.Features.Projects.Commands.DeleteCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Validation.Projects.Commands
{
    public sealed class DeletePropjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
    }
}
