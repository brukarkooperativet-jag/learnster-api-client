using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.UnitTests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Clients
{
    public class LearnsterAuthClientTests : BaseTest
    {
        private readonly LearnsterAuthClient _learnsterAuthClient;

        public LearnsterAuthClientTests()
        {
            var httpClientFactoryMock = HttpClientHelper.CreateHttpClientFactoryMock(HttpClientHandlerMock);

            _learnsterAuthClient = new LearnsterAuthClient(
                httpClientFactoryMock.Object,
                OptionMock.Object,
                NullLogger<LearnsterAuthClient>.Instance);
        }

        [Fact]
        public async Task GetToken_Success_ReturnToken()
        {
            // Arrange
            var expectedToken = new Fixture().Create<AuthToken>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedToken);
            
            // Act
            var token = await _learnsterAuthClient.GetToken();
            
            // Assert
            token.Should().NotBeNull();
            token.Should().BeEquivalentTo(expectedToken);
        }
        
        [Fact]
        public async Task GetToken_InternalServerError_ThrowException()
        {
            // Arrange
            var expectedToken = new Fixture().Create<AuthToken>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.InternalServerError, expectedToken);
            
            // Act, Assert
            await _learnsterAuthClient.Awaiting(x => x.GetToken()).Should().ThrowAsync<AuthLearnsterException>();
        }
    }
}