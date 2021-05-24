using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Repository
{
    public static class AddInjectionRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Add repositories here
            services.AddScoped<IWikidataRepository, WikidataRepository>();

            return services;
        }
    }
}
