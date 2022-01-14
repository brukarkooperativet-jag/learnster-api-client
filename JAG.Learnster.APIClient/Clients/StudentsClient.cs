using System.Text;
using System.Text.Json;
using JAG.Learnster.APIClient.Constants;
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
	public class StudentsClient : BaseAuthorizedClient, IStudentsClient
	{
		private readonly LearnsterOptions _learnsterOptions;
		private readonly ILogger<StudentsClient> _logger;
		
		public StudentsClient(IAuthClient authClient,
		                      IOptions<LearnsterOptions> learnsterOptions,
		                      ILogger<StudentsClient> logger)
			: base(authClient, logger)
		{
			_logger = logger;
			_learnsterOptions = learnsterOptions.Value;
		}

		/// <inheritdoc />
		public async Task<ResponseList<VendorStudent>> GetAllStudents()
		{
			using (var client = await CreateAuthorizedClient)
			{
#if DEBUG
				_logger.LogDebug("Getting student list from Learnster");
#endif

				var response = await client.GetAsync($"vendor/{_learnsterOptions.VendorId}/users/students/");

				if (response.IsSuccessStatusCode)
						return await response.DeserializeContent<ResponseList<VendorStudent>>();

				throw await CreateGetException(response, "Student list");
			}
		}

		/// <inheritdoc />
		public async Task<VendorStudent> CreateStudent(CreateUserRequest createUserRequest)
		{
#if DEBUG
			_logger.LogDebug("Creating Learnster student with email {Email}", createUserRequest.User.Email);
#endif
			
			using (var client = await CreateAuthorizedClient)
			{
				var request = new StringContent(
					JsonSerializer.Serialize(createUserRequest),
					Encoding.UTF8,
					ClientConstants.ContentType);

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
			
			using (var client = await CreateAuthorizedClient)
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