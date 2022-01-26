using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Constants;
using JAG.Learnster.APIClient.Exceptions;
using Microsoft.Extensions.Logging;

namespace JAG.Learnster.APIClient.Clients
{
	/// <summary>
	///  Base client with setup methods
	/// </summary>
	public abstract class BaseClient
	{
		private readonly ILogger<BaseClient> _logger;

		/// <summary>
		/// 
		/// </summary>
		protected BaseClient(ILogger<BaseClient> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Log error and throw exception for not success learnster response 
		/// </summary>
		protected async Task<Exception> ThrowGetException(HttpResponseMessage response,
		                                                  string entityName,
		                                                  params object[] args)
		{
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				var notFoundErrorMessage = $"{entityName} resource was not found";
				
				_logger.LogError(notFoundErrorMessage, args);
				throw new NotFoundLearnsterException(notFoundErrorMessage);
			}
			
			// TODO: [REFACTORING] Use model instead of string
			var errorContent = await response.Content.ReadAsStringAsync();
			var errorMessageWithDetails = $"Learnster client can't get {entityName} ({response.StatusCode}): {errorContent}";
                
			throw GetLearnsterException(args, errorMessageWithDetails);
		}
		
		/// <summary>
		/// Log error with arguments and throw exception for Post request
		/// </summary>
		protected async Task<Exception> CreatePostException(HttpResponseMessage response,
		                                                   string entityName,
		                                                   params object[] args)
		{
			// TODO: [REFACTORING] Use model instead of string
			var errorContent = await response.Content.ReadAsStringAsync();
			var errorMessageWithDetails = $"{entityName} cannot be created ({response.StatusCode}): {errorContent}";
                
			throw GetLearnsterException(args, errorMessageWithDetails);
		}

		/// <summary>
		/// Log error with arguments and throw exception for delete request
		/// </summary>
		protected async Task<Exception> CreateDeleteException(HttpResponseMessage response,
		                                                    string entityName,
		                                                    params object[] args)
		{
			// TODO: [REFACTORING] Use model instead of string
			var errorContent = await response.Content.ReadAsStringAsync();
			var errorMessageWithDetails = $"{entityName} cannot be deleted ({response.StatusCode}): {errorContent}";
                
			throw GetLearnsterException(args, errorMessageWithDetails);
		}

		private Exception GetLearnsterException(object[] args,
		                                    string errorMessageWithDetails)
		{
			_logger.LogError(errorMessageWithDetails, args);
			throw new LearnsterException(errorMessageWithDetails);
		}

		/// <summary>
		/// Create string content for http client
		/// </summary>
		protected StringContent CreateRequestContent(object contentObject)
		{
			return new StringContent(
				JsonSerializer.Serialize(contentObject),
				Encoding.UTF8,
				ClientConstants.ApplicationJsonContentType);
		}
	}
}