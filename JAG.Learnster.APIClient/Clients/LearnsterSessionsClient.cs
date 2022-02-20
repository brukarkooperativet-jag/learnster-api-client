using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

                var result = await GetResult<ResponseList<SessionShortWithAvatar>>(
                    response, "Can't get session list");
                
                return result.Results;
            }
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<PossibleChoicesSession>> GetAvailableForStudent(Guid studentId, bool? isCatalog = null)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri =
                    $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/sessions/possible-choices/";

                if (isCatalog.HasValue)
                    requestUri += $"?catalog={isCatalog}";

                var response = await client.GetAsync(requestUri);

                var result = await GetResult<ResponseList<PossibleChoicesSession>>(
                    response, $"Can't get available sessions for student {studentId}");
                
                return result.Results;
            }
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<SessionParticipant>> GetStudentSessions(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/sessions/";
                var response = await client.GetAsync(requestUri);

                var result = await GetResult<ResponseList<SessionParticipant>>(
                    response, $"Can't get student sessions for student {studentId}");
                
                return result.Results;
            }
        }
        
        /// <inheritdoc />
        public async Task<IReadOnlyCollection<StudentHistory>> GetStudentSessionsHistory(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/history/";
                var response = await client.GetAsync(requestUri);

                var result = await GetResult<ResponseList<StudentHistory>>(
                    response, $"Can't get student session history for student {studentId}");
                
                return result.Results;
            }
        }
    }
}