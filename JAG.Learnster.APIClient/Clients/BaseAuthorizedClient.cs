using System.Net;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Interfaces;
using Microsoft.Extensions.Logging;

namespace JAG.Learnster.APIClient.Clients
{
	public abstract class BaseAuthorizedClient
	{
		private readonly IAuthClient _authClient;
		private readonly ILogger<BaseAuthorizedClient> _logger;

		protected BaseAuthorizedClient(IAuthClient authClient,
		                               ILogger<BaseAuthorizedClient> logger)
		{
			_authClient = authClient;
			_logger = logger;
		}

		protected Task<HttpClient> CreateAuthorizedClient
			=> _authClient.CreateAuthorizedClient();

		protected async Task<Exception> CreateGetException(HttpResponseMessage response,
		                                                  string entityName,
		                                                  params object[] args)
		{
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				var notFoundErrorMessage = $"{entityName} resource was not found";
				
				_logger.LogError(notFoundErrorMessage, args);
				throw new NotFoundLearnsterException(notFoundErrorMessage);
			}
			
			// TODO: Use model instead of string
			var errorContent = await response.Content.ReadAsStringAsync();
			var errorMessageWithDetails = $"Learnster client can't get {entityName} ({response.StatusCode}): {errorContent}";
                
			_logger.LogError(errorMessageWithDetails, args);
			throw new LearnsterException(errorMessageWithDetails);
		}
		
		protected async Task<Exception> CreatePostException(HttpResponseMessage response,
		                                                   string entityName,
		                                                   params object[] args)
		{
			// TODO: Use model instead of string
			var errorContent = await response.Content.ReadAsStringAsync();
			var errorMessageWithDetails = $"{entityName} cannot be created ({response.StatusCode}): {errorContent}";
                
			_logger.LogError(errorMessageWithDetails, args);
			throw new LearnsterException(errorMessageWithDetails);
		}
		
		protected async Task<Exception> CreateDeleteException(HttpResponseMessage response,
		                                                    string entityName,
		                                                    params object[] args)
		{
			// TODO: Use model instead of string
			var errorContent = await response.Content.ReadAsStringAsync();
			var errorMessageWithDetails = $"{entityName} cannot be deleted ({response.StatusCode}): {errorContent}";
                
			_logger.LogError(errorMessageWithDetails, args);
			throw new LearnsterException(errorMessageWithDetails);
		}
	}
}