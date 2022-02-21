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
        public Task<IReadOnlyCollection<SessionShortWithAvatar>> GetAll()
        {
#if DEBUG
            _logger.LogDebug("Getting list of sessions");
#endif

            return GetAllItems(Get);
        }
        
        /// <inheritdoc />
        public async Task<ResponseList<SessionShortWithAvatar>> Get(int page, int count)
        {
#if DEBUG
            _logger.LogDebug($"Getting {count} sessions on {page} page from Learnster");
#endif
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/sessions/?{GetPaginationQuery(page, count)}";
                var response = await client.GetAsync(requestUri);

                var result = await GetResult<ResponseList<SessionShortWithAvatar>>(
                    response, "Can't get session list");
                return result;
            }
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<PossibleChoicesSession>> GetAvailableForStudent(Guid studentId, bool? isCatalog = null)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif

            return GetAllItems((page, count) => GetAvailableForStudent(page, count, studentId, isCatalog));
        }

        private async Task<ResponseList<PossibleChoicesSession>> GetAvailableForStudent(
            int page,
            int count,
            Guid studentId,
            bool? isCatalog = null)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/" +
                                 $"sessions/possible-choices/?{GetPaginationQuery(page, count)}";

                if (isCatalog.HasValue)
                    requestUri += $"&catalog={isCatalog}";

                var response = await client.GetAsync(requestUri);

                return await GetResult<ResponseList<PossibleChoicesSession>>(
                    response, $"Can't get available sessions for student {studentId}");
            }
        }

        /// <inheritdoc />
        public Task<IReadOnlyCollection<SessionParticipant>> GetStudentSessions(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif
            return GetAllItems((page, count) => GetStudentSessions(page, count, studentId));
        }
        
        private async Task<ResponseList<SessionParticipant>> GetStudentSessions(int page, int count, Guid studentId)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/" +
                                 $"students/{studentId}/sessions/?{GetPaginationQuery(page, count)}";
                var response = await client.GetAsync(requestUri);

                return await GetResult<ResponseList<SessionParticipant>>(
                    response, $"Can't get student sessions for student {studentId}");
            }
        }
        
        /// <inheritdoc />
        public Task<IReadOnlyCollection<StudentHistory>> GetStudentSessionsHistory(Guid studentId)
        {
#if DEBUG
            _logger.LogDebug($"Getting session list for student {studentId}", studentId);
#endif

            return GetAllItems((page, count) => GetStudentSessionsHistory(page, count, studentId));
        }
        
        private async Task<ResponseList<StudentHistory>> GetStudentSessionsHistory(int page, int count, Guid studentId)
        {
            using (var client = await _httpClientFactory.CreateAuthorizedClient())
            {
                var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/" +
                                 $"history/?{GetPaginationQuery(page, count)}";
                var response = await client.GetAsync(requestUri);

                return await GetResult<ResponseList<StudentHistory>>(
                    response, $"Can't get student session history for student {studentId}");
            }
        }
    }
}