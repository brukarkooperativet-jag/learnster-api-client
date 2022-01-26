using System.Net.Http;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Exceptions;

namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    /// Provide http clients to work with Learnster 
    /// </summary>
    public interface ILearnsterHttpClientFactory
    {
        /// <summary>
        /// Create authorized client for Learnster API
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AuthLearnsterException">Error authorizing in the system</exception>
        Task<HttpClient> CreateAuthorizedClient();
    }
}