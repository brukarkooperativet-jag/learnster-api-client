using System.Net.Http;
using System.Reflection;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.IntegrationTests.Options;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class BaseClientTests
	{
		protected readonly Mock<IOptions<LearnsterOptions>> LearnsterOptionsMock;
		protected readonly IAuthClient AuthClient;
		protected readonly LearnsterOptions LearnsterOptionsValue;
		protected readonly TestLearnsterOptions TestLearnsterOptions;

		protected readonly IConfiguration Configuration;

		protected BaseClientTests()
		{
			Configuration = BuildConfiguration();
			LearnsterOptionsValue = GetClientOptions();
			TestLearnsterOptions = GetTestLearnsterOptions();
			
			var clientFactory = new Mock<IHttpClientFactory>();
			clientFactory
				.Setup(x => x.CreateClient(Microsoft.Extensions.Options.Options.DefaultName))
				.Returns(() => new HttpClient());
			
			LearnsterOptionsMock = new Mock<IOptions<LearnsterOptions>>();
			LearnsterOptionsMock.Setup(x => x.Value).Returns(LearnsterOptionsValue);
			
			AuthClient = new AuthClient(
				clientFactory.Object,
				LearnsterOptionsMock.Object,
				NullLogger<AuthClient>.Instance);
		}

		private IConfiguration BuildConfiguration()
		{
			return new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables()
				.AddUserSecrets(Assembly.GetCallingAssembly())
				.Build();
		}

		private LearnsterOptions GetClientOptions()
		{
			return Configuration
				.GetSection(LearnsterOptions.SECTION_NAME)
				.Get<LearnsterOptions>();
		}
		
		private TestLearnsterOptions GetTestLearnsterOptions()
		{
			return Configuration
				.GetSection(TestLearnsterOptions.SECTION_NAME)
				.Get<TestLearnsterOptions>();
		}
	}
}