using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JAG.Learnster.APIClient.Extensions
{
    /// <summary>
    /// Service collection extension methods
    /// </summary>
    public static class ServiceCollectionHelper
    {
        /// <summary>
        /// Register default implementation for LearnsterClient 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterLearnsterClient(this IServiceCollection services)
        {
            services.AddScoped<ILearnsterHttpClientFactory, LearnsterHttpClientFactory>();
            services.AddScoped<ILearnsterUrlBuilder, LearnsterUrlBuilder>();
            
            services.AddScoped<ILearnsterClient, LearnsterClient>();
            services.AddScoped<ILearnsterAuthClient, LearnsterAuthClient>();
            services.AddScoped<ILearnsterSessionsClient, LearnsterSessionsClient>();
            services.AddScoped<ILearnsterStudentsClient, LearnsterStudentsClient>();
            services.AddScoped<ILearnsterTeamClient, LearnsterTeamClient>();

            return services;
        }
    }
}