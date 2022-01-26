using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class AuthClientTests : BaseClientTests
	{
		private readonly ILearnsterAuthClient _client;

		public AuthClientTests()
		{
			_client = ServiceProvider.GetRequiredService<ILearnsterAuthClient>();
		}

		[Fact]
		public async Task GetToken_ValidKey_Success()
		{
			// Act
			var result = await _client.GetToken();
			
			// Assert
			result.Should().NotBeNull();
		}
	}
}