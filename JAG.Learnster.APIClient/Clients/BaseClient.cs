using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Constants;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Extensions;
using JAG.Learnster.APIClient.Models;
using Microsoft.Extensions.Logging;

namespace JAG.Learnster.APIClient.Clients
{
	/// <summary>
	///  Base client with setup methods
	/// </summary>
	public abstract class BaseClient
	{
		private readonly ILogger<BaseClient> _logger;

		protected BaseClient(ILogger<BaseClient> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Log error and throw exeption if responste status is not success
		/// </summary>
		/// <param name="response"></param>
		/// <param name="errorMessage"></param>
		/// <exception cref="Exception"></exception>
		protected async Task GetActionResult(HttpResponseMessage response,
		                                     string errorMessage)
		{
			if (response.IsSuccessStatusCode)
				return;

			throw await GetException(response, errorMessage, s => new LearnsterException(s));
		}

		protected Task<TResult> GetResult<TResult>(HttpResponseMessage response,
		                                           string errorMessage)
		{
			return GetResult<TResult>(response, errorMessage, str => new LearnsterException(str));
		}

		protected async Task<TResult> GetResult<TResult>(HttpResponseMessage response,
		                                                  string errorMessage,
		                                                  Func<string, Exception> exceptionFunc)
		{
			if (response.IsSuccessStatusCode)
				return await response.DeserializeContent<TResult>();

			throw await GetException(response, errorMessage, exceptionFunc);
		}

		private async Task<Exception> GetException(HttpResponseMessage response,
		                                           string errorMessage,
		                                           Func<string, Exception> exceptionFunc)
		{
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				_logger.LogError($"{errorMessage}. Resource cannot be found.");
				throw new NotFoundLearnsterException($"{errorMessage}. Resource cannot be found.");
			}

			if (response.StatusCode == HttpStatusCode.BadRequest)
			{
				ErrorResponse errorModel; 

				try
				{
					errorModel = await response.DeserializeContent<ErrorResponse>();
				}
				catch (Exception e)
				{
					throw new LearnsterException($"{errorMessage} ({response.StatusCode})." +
					                             $" Server response cannot be processed: {e.Message}");
				}
			
				var combinedErrorMessage = $"{errorMessage} ({response.StatusCode}): {errorModel}";
				
				_logger.LogError(combinedErrorMessage);
				throw exceptionFunc(combinedErrorMessage);
			}
			
			throw exceptionFunc($"{errorMessage} ({response.StatusCode}).");
		}
	}
}