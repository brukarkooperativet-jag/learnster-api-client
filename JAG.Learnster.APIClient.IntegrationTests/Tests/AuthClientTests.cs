using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Interfaces;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class AuthClientTests : BaseClientTests
	{
		private readonly IAuthClient _client;

		public AuthClientTests()
		{
			_client = AuthClient;
		}

		[Fact]
		public async Task GetToken_ValidKey_Success()
		{
			// Act
			var result = await _client.GetToken();
			
			// Assert
			result.Should().NotBeNull();
		}
		
		[Fact]
		public async Task GetToken_InvalidKey_ThrowException()
		{
			// Arrange
			LearnsterOptionsValue.ClientSecret = "FakeSecret";
			
			// Act, Assert
			await _client.Invoking(x => x.GetToken()).Should().ThrowAsync<LearnsterException>();
		}
	}
}