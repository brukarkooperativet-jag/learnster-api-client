using System.Net.Http;
using AutoFixture;
using JAG.Learnster.APIClient.Options;
using Microsoft.Extensions.Options;
using Moq;

namespace JAG.Learnster.APIClient.UnitTests.Tests
{
    public class BaseTest
    {
        protected readonly LearnsterOptions LearnsterOptions;
        protected readonly Mock<IOptions<LearnsterOptions>> OptionMock;
        protected readonly Mock<HttpClientHandler> HttpClientHandlerMock;
        protected readonly Fixture Fixture;

        public BaseTest()
        {
            LearnsterOptions = new Fixture().Create<LearnsterOptions>();
            OptionMock = new Mock<IOptions<LearnsterOptions>>();
            OptionMock.Setup(x => x.Value).Returns(LearnsterOptions);
            
            HttpClientHandlerMock = new Mock<HttpClientHandler>();

            Fixture = new Fixture();
        }
    }
}