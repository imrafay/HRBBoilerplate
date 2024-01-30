using Application.Common.Interfaces.Persistence;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureDependency(
            this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            return services;

        }
    }
}
