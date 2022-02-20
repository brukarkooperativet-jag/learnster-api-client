using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Clients
{
	/// <inheritdoc cref="JAG.Learnster.APIClient.Interfaces.ILearnsterAuthClient" />
	public class LearnsterAuthClient : BaseClient, ILearnsterAuthClient
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly LearnsterOptions _learnsterOptions;
		private readonly ILogger<LearnsterAuthClient> _logger;

		public LearnsterAuthClient(IHttpClientFactory httpClientFactory,
		                           IOptions<LearnsterOptions> learnsterOptions,
		                           ILogger<LearnsterAuthClient> logger)
			: base(logger)
		{
			_httpClientFactory = httpClientFactory;
			_learnsterOptions = learnsterOptions.Value;
			_logger = logger;
		}

		/// <inheritdoc />
		public async Task<AuthToken> GetToken()
		{
#if DEBUG
			_logger.LogDebug("Getting auth token from Learnster");
#endif

			using (var client = _httpClientFactory.CreateClient())
			{
				client.BaseAddress = _learnsterOptions.ApiV1Url;

				var requestBody = new GetTokenRequest()
				{
					ClientId = _learnsterOptions.ClientId,
					ClientSecret = _learnsterOptions.ClientSecret,
					GrantType = _learnsterOptions.GrantType
				};

				var response = await client.PostAsJsonAsync("auth/token/", requestBody);

				return await GetResult<AuthToken>(
					response,
					"Learnster client cannot be authorized",
					x => new AuthLearnsterException(x));
			}
		}
	}
}