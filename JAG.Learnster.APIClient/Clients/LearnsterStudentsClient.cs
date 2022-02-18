using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests.Student;
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
		public async Task<IReadOnlyCollection<VendorStudent>> GetAll()
		{
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
#if DEBUG
				_logger.LogDebug("Getting student list from Learnster");
#endif

				var response = await client.GetAsync($"vendor/{_learnsterOptions.VendorId}/users/students/");

				var result = await GetResult<ResponseList<VendorStudent>>(response, "Can't get student list");
				return result.Results;
			}
		}

		/// <inheritdoc />
		public async Task<IReadOnlyCollection<VendorStudent>> SearchStudents(string searchString)
		{
#if DEBUG
			_logger.LogDebug("Getting student list from Learnster");
#endif

			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var requestUrl = $"vendor/{_learnsterOptions.VendorId}/users/students/?search={searchString}";
				var response = await client.GetAsync(requestUrl);

				var result = await GetResult<ResponseList<VendorStudent>>(
					response, $"Student searching '{searchString}' has been failed");
				return result.Results;
			}
		}

		/// <inheritdoc />
		public async Task<VendorStudent> GetStudentByPersonalId(string personalId)
		{
#if DEBUG
			_logger.LogDebug("Getting student list from Learnster");
#endif
			
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var requestUrl = $"vendor/{_learnsterOptions.VendorId}/users/students/?personal_id={personalId}";
				var response = await client.GetAsync(requestUrl);
				
				var result = await GetResult<ResponseList<VendorStudent>>(response,
					$"Can't get student with PersonalId {personalId}");
				return result.Results.FirstOrDefault();
			}
		}

		/// <inheritdoc />
		public async Task<VendorStudent> CreateStudent(CreateStudentRequest createStudentRequest)
		{
#if DEBUG
			_logger.LogDebug("Creating Learnster student with email {Email}", createStudentRequest.User.Email);
#endif
			
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var response = await client.PostAsJsonAsync($"vendor/{_learnsterOptions.VendorId}/users/students/", createStudentRequest);

				var errorMessage = string.IsNullOrWhiteSpace(createStudentRequest.User.PersonalId)
					? "Can't create user"
					: $"Can't create user with personalId {createStudentRequest.User.PersonalId}";
				
				// TODO: Test error with long name (>30)
				var result = await GetResult<VendorStudent>(response, errorMessage);
				return result;
			}
		}
		
		/// <inheritdoc />
		public async Task<VendorStudent> UpdateStudent(UpdateStudentRequest updateStudentRequest)
		{
#if DEBUG
			_logger.LogDebug("Updating Learnster student with id {LearnsterId}", updateStudentRequest.StudentId);
#endif
			if (updateStudentRequest.StudentId == default)
				throw new ArgumentException(nameof(updateStudentRequest.StudentId));
			
			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var url = $"vendor/{_learnsterOptions.VendorId}/users/students/{updateStudentRequest.StudentId}/";
				var response = await client.PutAsJsonAsync(url, updateStudentRequest);

				// TODO: Test error with long name (>30)
				var result = await GetResult<VendorStudent>(response,
					$"Can't update student {updateStudentRequest.StudentId}");
				return result;
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

				await GetActionResult(response, $"Can't deactivate student {studentId}");
			}
		}
		
		/// <inheritdoc />
		public Task<VendorStudent> DeactivateStudent(Guid studentId)
		{
#if DEBUG
			_logger.LogDebug("Deactivate Learnster student with id {LearnsterId}", studentId);
#endif

			return ChangeActiveStatus(studentId, false, $"Can't deactivate student {studentId}");
		}

		/// <inheritdoc />
		public Task<VendorStudent> ActivateStudent(Guid studentId)
		{
#if DEBUG
			_logger.LogDebug("Deactivate Learnster student with id {LearnsterId}", studentId);
#endif

			return ChangeActiveStatus(studentId, true, $"Can't activate student {studentId}");
		}

		private async Task<VendorStudent> ChangeActiveStatus(Guid studentId, bool isActive, string errorMessage)
		{
			if (studentId == default)
				throw new ArgumentException("StudentId cannot be empty", nameof(studentId));

			using (var client = await _httpClientFactory.CreateAuthorizedClient())
			{
				var deactivateModel = JsonContent.Create(new ActivateStatusRequest(isActive));

				var url = $"vendor/{_learnsterOptions.VendorId}/users/students/{studentId}/";
				var response = await client.PatchAsync(url, deactivateModel);

				var result = await GetResult<VendorStudent>(response, errorMessage);
				return result;
			}
		}
	}
}