using System;
using System.Reflection;
using JAG.Learnster.APIClient.Extensions;
using JAG.Learnster.APIClient.IntegrationTests.Options;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class BaseClientTests
	{
		protected readonly IServiceProvider ServiceProvider;
		protected readonly IConfiguration Configuration;
		

		protected BaseClientTests()
		{
			Configuration = BuildConfiguration();

			ServiceProvider = new ServiceCollection()
				.Configure<LearnsterOptions>(Configuration.GetSection(LearnsterOptions.SectionName))
				.Configure<TestLearnsterOptions>(Configuration.GetSection(TestLearnsterOptions.SECTION_NAME))
				.AddHttpClient()
				.RegisterLearnsterClient()
				.BuildServiceProvider();
		}

		protected TestLearnsterOptions TestLearnsterOptions
			=> ServiceProvider.GetRequiredService<IOptions<TestLearnsterOptions>>().Value;

		private IConfiguration BuildConfiguration()
		{
			return new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables()
				.AddUserSecrets(Assembly.GetCallingAssembly())
				.Build();
		}
	}
}