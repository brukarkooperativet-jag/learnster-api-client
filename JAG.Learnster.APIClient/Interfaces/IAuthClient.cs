using System.Net.Http;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models.ApiContracts;

namespace JAG.Learnster.APIClient.Interfaces
{
    public interface IAuthClient
    {
        /// <summary>
        /// Get new auth token from API
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AuthLearnsterException">Error getting auth token</exception>
        Task<AuthToken> GetToken();
        
        /// <summary>
        /// Create authorized client for Learnster API
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AuthLearnsterException">Error authorizing in the system</exception>
        Task<HttpClient> CreateAuthorizedClient();
    }
}