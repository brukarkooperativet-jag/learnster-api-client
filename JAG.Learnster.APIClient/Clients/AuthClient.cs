using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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
	public class AuthClient : IAuthClient
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly LearnsterOptions _learnsterOptions;
		private readonly ILogger<AuthClient> _logger;

		private static LearnsterToken _cachedToken;
		
		private static readonly AutoResetEvent AutoResetEvent = new AutoResetEvent(true);
		private const int EventTimeout = 5 * 60 * 1000; // 5 minutes
		private const int TimeForApiRequest = 20;

		public AuthClient(IHttpClientFactory httpClientFactory,
		                  IOptions<LearnsterOptions> learnsterOptions,
		                  ILogger<AuthClient> logger)
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
				
				var request = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, ClientConstants.ContentType);
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

		/// <inheritdoc />
		public async Task<HttpClient> CreateAuthorizedClient()
		{
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = _learnsterOptions.ApiUrl;
			
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
					var token = await GetToken();
					_cachedToken = new LearnsterToken
					{
						Token = token.AccessToken,
						EndDateTime = getTokenTime.AddSeconds(token.ExpiresIn)
					};
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