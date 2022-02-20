using System.Threading.Tasks;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models.ApiContracts;

namespace JAG.Learnster.APIClient.Interfaces
{
    /// <summary>
    /// Client to with with api auth
    /// </summary>
    public interface ILearnsterAuthClient
    {
        /// <summary>
        /// Get new auth token from API
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AuthLearnsterException">Error getting auth token</exception>
        Task<AuthToken> GetToken();
    }
}