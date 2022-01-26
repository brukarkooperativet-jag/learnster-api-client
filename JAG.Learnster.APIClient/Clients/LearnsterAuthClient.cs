using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Constants;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Clients
{
	/// <inheritdoc />
	public class LearnsterAuthClient : ILearnsterAuthClient
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly LearnsterOptions _learnsterOptions;
		private readonly ILogger<LearnsterAuthClient> _logger;

		/// <summary>
		/// 
		/// </summary>
		public LearnsterAuthClient(IHttpClientFactory httpClientFactory,
		                           IOptions<LearnsterOptions> learnsterOptions,
		                           ILogger<LearnsterAuthClient> logger)
		{
			_httpClientFactory = httpClientFactory;
			_learnsterOptions = learnsterOptions.Value;
			_logger = logger;
		}

		/// <inheritdoc />
		public async Task<AuthToken> GetToken()
		{
			using (var client = _httpClientFactory.CreateClient())
			{
				client.BaseAddress = _learnsterOptions.ApiUrl;
				
				var requestBody = new GetTokenRequest()
				{
					ClientId = _learnsterOptions.ClientId,
					ClientSecret = _learnsterOptions.ClientSecret,
					GrantType = _learnsterOptions.GrantType
				};
				
				
#if DEBUG
				_logger.LogDebug("Getting auth token from Learnster");
#endif
				
				var request = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, ClientConstants.ApplicationJsonContentType);
				var response = await client.PostAsync("auth/token/", request);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					var token = JsonSerializer.Deserialize<AuthToken>(responseContent);
					return token;
				}
				
				var errorResponseContent = await response.Content.ReadAsStringAsync();
				var errorModel = JsonSerializer.Deserialize<ErrorResponse>(errorResponseContent);

				var errorMessage = $"Learnster client cannot be authorized: {errorModel?.Error ?? response.StatusCode.ToString()}";

				_logger.LogError($"{errorMessage}. Response: {errorResponseContent}");
				throw new AuthLearnsterException(errorMessage);
			}
		}
	}
}