using Microsoft.Extensions.DependencyInjection;

namespace JAG.Learnster.APIClient.Helpers
{
    public static class ServiceCollectionHelper
    {
        /// <summary>
        /// Register default implementation for LearnsterClient 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterLearnsterClient(this IServiceCollection services)
        {
            // TODO: TBD
            
            return services;
        }
    }
}