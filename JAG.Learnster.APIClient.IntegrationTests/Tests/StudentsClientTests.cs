using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class StudentsClientTests : BaseClientTests
	{
		private readonly StudentsClient _client;

		public StudentsClientTests()
		{
			_client = new StudentsClient(
				AuthClient,
				LearnsterOptionsMock.Object,
				NullLogger<StudentsClient>.Instance);
		}

		[Fact]
		public async Task GetAllStudents_Success()
		{
			// Act
			var students = await _client.GetAllStudents();
			
			// Assert
			students.Should().NotBeNull();
		}
	}
}