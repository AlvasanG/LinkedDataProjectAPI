using Microsoft.Extensions.DependencyInjection;

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
