using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Services
{
    /// <summary>
    /// Provider of HTTP Clients for access to learnster API
    /// </summary>
    public class LearnsterHttpClientFactory : ILearnsterHttpClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly LearnsterOptions _learnsterOptions;
        private readonly ILogger<LearnsterHttpClientFactory> _logger;
        private readonly ILearnsterAuthClient _authClient;

        private static LearnsterToken _cachedToken;

        private static readonly AutoResetEvent AutoResetEvent = new AutoResetEvent(true);
        // Not a const to change from unit tests
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        // ReSharper disable once ConvertToConstant.Local
        private static int EventTimeout = 5 * 60 * 1000; // 5 minutes
        private const int TimeForApiRequest = 20;

        /// <summary>
        /// 
        /// </summary>
        public LearnsterHttpClientFactory(IHttpClientFactory httpClientFactory,
                                          IOptions<LearnsterOptions> learnsterOptions,
                                          ILogger<LearnsterHttpClientFactory> logger,
                                          ILearnsterAuthClient authClient)
        {
            _httpClientFactory = httpClientFactory;
            _learnsterOptions = learnsterOptions.Value;
            _logger = logger;
            _authClient = authClient;
        }

        /// <inheritdoc />
        public async Task<HttpClient> CreateAuthorizedClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = _learnsterOptions.ApiV1Url;

            if (!AutoResetEvent.WaitOne(EventTimeout))
            {
                var errorMessage = "Learnster client can't get auth token. Token updating is busy";
                _logger.LogError($"{nameof(TimeoutException)}: {errorMessage}");
                throw new TimeoutException(errorMessage);
            }

            try
            {
                if (!TokenIsActive)
                {
                    var getTokenTime = DateTime.Now;
                    var token = await _authClient.GetToken();
                    _cachedToken = new LearnsterToken
                    {
                        Token = token.AccessToken,
                        EndDateTime = getTokenTime.AddSeconds(token.ExpiresIn)
                    };

#if DEBUG
                    _logger.LogDebug($"Learnster token cached for {token.ExpiresIn} seconds");
#endif
                }
            }
            finally
            {
                AutoResetEvent.Set();
            }

            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _cachedToken.Token);

            return client;
        }

        private static bool TokenIsActive
            => _cachedToken != null
               && _cachedToken.EndDateTime.AddSeconds(-TimeForApiRequest) > DateTime.Now;
    }
}