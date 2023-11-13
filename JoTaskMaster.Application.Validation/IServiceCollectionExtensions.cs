﻿using FluentValidation;
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
using JoTaskMaster.Application.Validation.Projects.Commands;

namespace JoTaskMaster.Application.Validation
{
    public static class IServiceCollectionExtensions
    {

        public static void AddAplicationValidationLayer(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateProjectCommand>, CreateProjectCommandValidator>();

        }
    }
    
}