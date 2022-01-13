using System.Text.Json;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
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
			: base(authClient)
		{
			_logger = logger;
			_learnsterOptions = learnsterOptions.Value;
		}

		/// <inheritdoc />
		public async Task<ResponseList<VendorStudents>> GetAllStudents()
		{
			using (var client = await AuthorizedClient)
			{
#if DEBUG
				_logger.LogDebug("Getting student list from Learnster");
#endif

				var response = await client.GetAsync($"vendor/{_learnsterOptions.VendorId}/users/students/");

				if (response.IsSuccessStatusCode)
					await using (var contentStream = await response.Content.ReadAsStreamAsync())
						return await JsonSerializer.DeserializeAsync<ResponseList<VendorStudents>>(contentStream);

				var errorContent = await response.Content.ReadAsStringAsync();
				var errorMessage = $"Can't get student list ({response.StatusCode}): {errorContent}";

				_logger.LogError(errorMessage);
				throw new LearnsterException(errorMessage);
			}
		}
	}
}