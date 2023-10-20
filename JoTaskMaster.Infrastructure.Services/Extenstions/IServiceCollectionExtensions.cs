using JoTaskMaster.Application.Interfaces.Services;
using JoTaskMaster.Domain;
using JoTaskMaster.Infrastructure.Services.Interfaces;
using JoTaskMaster.Infrastructure.Services.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Infrastructure.Services.Extenstions
{
    public static class IServiceCollectionExtensions
    {

        public static void AddInfrasctructureLayer(this IServiceCollection services)
        {

            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ISecurityService, SecurityService>()
                .AddTransient<ICompanyService, CompanyService>(); 


        }
    }
}
