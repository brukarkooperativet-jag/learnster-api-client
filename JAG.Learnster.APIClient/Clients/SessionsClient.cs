using JAG.Learnster.APIClient.Extensions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Clients
{
    public class SessionsClient : BaseAuthorizedClient, ISessionsClient
    {
        private readonly ILogger<SessionsClient> _logger;
        private readonly LearnsterOptions _learnsterOptions;

        public SessionsClient(IAuthClient authClient,
                             ILogger<SessionsClient> logger,
                             IOptions<LearnsterOptions> learnsterOptions)
            : base(authClient, logger)
        {
            _logger = logger;
            _learnsterOptions = learnsterOptions.Value;
        }

        public async Task<ResponseList<PossibleChoicesSessionsList>> GetAvailableForStudent(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            
            using (var client = await CreateAuthorizedClient)
            {
                var requestUri =
                    $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/sessions/possible-choices/";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                    return await response.DeserializeContent<ResponseList<PossibleChoicesSessionsList>>();

                throw await CreateGetException(response, "Session list for student", studentId);
            }
        }
    }
}