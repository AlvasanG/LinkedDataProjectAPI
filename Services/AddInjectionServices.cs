using LinkedDataProjectAPI.Services.Implementations;
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
            services.AddScoped<IEntitiesService, EntitiesService>();
            services.AddScoped<ILanguageSearchService, LanguageSearchService>();

            return services;
        }
    }
}
