using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Extensions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Clients
{
    /// <inheritdoc cref="JAG.Learnster.APIClient.Interfaces.ILearnsterSessionsClient" />
    public class LearnsterSessionsClient : BaseClient, ILearnsterSessionsClient
    {
        private readonly ILogger<LearnsterSessionsClient> _logger;
        private readonly LearnsterOptions _learnsterOptions;
        private readonly ILearnsterHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 
        /// </summary>
        public LearnsterSessionsClient(ILogger<LearnsterSessionsClient> logger,
                                       IOptions<LearnsterOptions> learnsterOptions,
                                       ILearnsterHttpClientFactory httpClientFactory)
            : base(logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _learnsterOptions = learnsterOptions.Value;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<SessionShortWithAvatar>> GetAll()
        {
#if DEBUG
            _logger.LogDebug("Getting list of sessions");
#endif
            
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/sessions/";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                    return (await response.DeserializeContent<ResponseList<SessionShortWithAvatar>>()).Results;

                throw await ThrowGetException(response, "Session list");
            }
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<PossibleChoicesSession>> GetAvailableForStudent(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri =
                    $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/sessions/possible-choices/";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                    return await response
                        .DeserializeContent<ResponseList<PossibleChoicesSession>>()
                        .ContinueWith(x => x.Result.Results);

                throw await ThrowGetException(response, "Available session list for student", studentId);
            }
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<UserCourseParticipant>> GetStudentSessions(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/sessions/";
                var response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                    return await response
                        .DeserializeContent<ResponseList<UserCourseParticipant>>()
                        .ContinueWith(x => x.Result.Results);

                throw await ThrowGetException(response, "Student session list", studentId);
            }
        }
    }
}