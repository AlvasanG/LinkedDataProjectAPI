using LinkedDataProjectAPI.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedDataProjectAPI.Services
{
    public static class AddInjectionServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add services here
            services.AddScoped<IEntitiesService, EntitiesService>();
            services.AddScoped<ILanguageSearchService, LanguageSearchService>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<ISearchEntitiesService, SearchEntitiesService>();
            services.AddScoped<IWikidataService, WikidataService>();

            return services;
        }
    }
}
