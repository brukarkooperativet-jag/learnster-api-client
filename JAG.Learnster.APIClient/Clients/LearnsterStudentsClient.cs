using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Extensions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.Clients
{
	/// <inheritdoc cref="JAG.Learnster.APIClient.Interfaces.ILearnsterStudentsClient" />
	public class LearnsterStudentsClient : BaseClient, ILearnsterStudentsClient
	{
		private readonly LearnsterOptions _learnsterOptions;
		private readonly ILogger<LearnsterStudentsClient> _logger;
		private readonly ILearnsterHttpClientFactory _httpClientFactory;
		
		/// <summary>
		/// 
		/// </summary>
		public LearnsterStudentsClient(IOptions<LearnsterOptions> learnsterOptions,
		                               ILogger<LearnsterStudentsClient> logger,
		                               ILearnsterHttpClientFactory httpClientFactory)
			: base(logger)
		{
			_logger = logger;
			_httpClientFactory = httpClientFactory;
			_learnsterOptions = learnsterOptions.Value;
		}

		/// <inheritdoc />
		public async Task<IReadOnlyCollection<VendorStudent>> GetAllStudents()
		{
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
#if DEBUG
				_logger.LogDebug("Getting student list from Learnster");
#endif

				var response = await client.GetAsync($"vendor/{_learnsterOptions.VendorId}/users/students/");

				if (response.IsSuccessStatusCode)
						return await response
							.DeserializeContent<ResponseList<VendorStudent>>()
							.ContinueWith(x => x.Result.Results);

				throw await ThrowGetException(response, "Student list");
			}
		}

		/// <inheritdoc />
		public async Task<IReadOnlyCollection<VendorStudent>> SearchStudents(string searchString)
		{
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
#if DEBUG
				_logger.LogDebug("Getting student list from Learnster");
#endif

				var requestUrl = $"vendor/{_learnsterOptions.VendorId}/users/students?search={searchString}";
				var response = await client.GetAsync(requestUrl);

				if (response.IsSuccessStatusCode)
				{
					return await response
						.DeserializeContent<ResponseList<VendorStudent>>()
						.ContinueWith(x => x.Result.Results);
				}
				
				throw await ThrowGetException(response, "Student by email");
			}
		}

		/// <inheritdoc />
		public async Task<VendorStudent> CreateStudent(CreateUserRequest createUserRequest)
		{
#if DEBUG
			_logger.LogDebug("Creating Learnster student with email {Email}", createUserRequest.User.Email);
#endif
			
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var request = CreateRequestContent(createUserRequest);
				var response = await client.PostAsync($"vendor/{_learnsterOptions.VendorId}/users/students/", request);

				if (response.IsSuccessStatusCode)
					return await response.DeserializeContent<VendorStudent>();

				// TODO: Test error with long name (>30)
				throw await CreatePostException(response, "Student", createUserRequest.User.Email);
			}
		}

		/// <inheritdoc />
		public async Task DeleteStudent(Guid studentId)
		{
#if DEBUG
			_logger.LogDebug("Deleting Learnster student {StudentId}", studentId);
#endif
			
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var requestUri = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/";
				var response = await client.DeleteAsync(requestUri);

				if (response.IsSuccessStatusCode)
					return;

				throw await CreateDeleteException(response, "Student", studentId);
			}
		}
	}
}