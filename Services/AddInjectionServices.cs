using LinkedDataProjectAPI.Services.Implementatios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services
{
    public static class AddInjectionServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add services here
            services.AddScoped<IGetEntitiesService, GetEntitiesService>();

            return services;
        }
    }
}
