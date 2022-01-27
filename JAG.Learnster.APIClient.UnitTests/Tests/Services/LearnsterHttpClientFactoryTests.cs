using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Options;
using JAG.Learnster.APIClient.Services;
using JAG.Learnster.APIClient.UnitTests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Services
{
    public class LearnsterHttpClientFactoryTests : BaseTest
    {
        private readonly LearnsterHttpClientFactory _client;
        private readonly Mock<ILearnsterAuthClient> _authClient;

        public LearnsterHttpClientFactoryTests()
        {
            var httpClientFactoryMock = HttpClientHelper.CreateHttpClientFactoryMock(HttpClientHandlerMock);
            
            var optionMock = new Mock<IOptions<LearnsterOptions>>();
            optionMock.Setup(x => x.Value).Returns(LearnsterOptions);
            
            _authClient = new Mock<ILearnsterAuthClient>();

            _client = new LearnsterHttpClientFactory(
                httpClientFactoryMock.Object,
                optionMock.Object,
                NullLogger<LearnsterHttpClientFactory>.Instance,
                _authClient.Object);
            
            SetupAutoResetEvent(true);
        }

        [Fact]
        public async Task CreateAuthorizedClient_AuthClientThrowException_ThrowException()
        {
            // Arrange
            _authClient.Setup(x => x.GetToken()).Throws<Exception>();
            
            // Act, Assert
            await _client.Invoking(x => x.CreateAuthorizedClient()).Should().ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task CreateAuthorizedClient_CreateNewToken_CreateNewTokenAndReturnClient()
        {
            // Arrange
            _authClient.Setup(x => x.GetToken()).ReturnsAsync(new AuthToken());
            SetCachedToken(null);

            // Act
            var resultClient = await _client.CreateAuthorizedClient();
            
            // Assert
            _authClient.Verify(x=> x.GetToken(), Times.Once);
            resultClient.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateAuthorizedClient_TokenIsNotActual_CreateNewTokenAndReturnClient()
        {
            // Arrange
            _authClient.Setup(x => x.GetToken()).ReturnsAsync(new AuthToken());
            SetCachedToken(new LearnsterToken() { EndDateTime = DateTime.Now.AddYears(-10) });
            
            // Act
            var resultClient = await _client.CreateAuthorizedClient();
            
            // Assert
            _authClient.Verify(x=> x.GetToken(), Times.Once);
            resultClient.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateAuthorizedClient_TokenExistAndActual_CreateClientWithExistToken()
        {
            // Arrange
            SetCachedToken(new LearnsterToken() { EndDateTime = DateTime.MaxValue });

            // Act
            var resultClient = await _client.CreateAuthorizedClient();

            
            // Assert
            _authClient.Verify(x=> x.GetToken(), Times.Never);
            resultClient.Should().NotBeNull();
        }
        
        [Fact]
        public async Task CreateAuthorizedClient_AnUpdateBusy_ThrowTimeoutException()
        {
            // Arrange
            var eventTimeoutField = typeof(LearnsterHttpClientFactory).GetField("EventTimeout", BindingFlags.NonPublic | BindingFlags.Static);
            eventTimeoutField.SetValue(null, 1);

            SetupAutoResetEvent(false);

            // Act, Assert
            await _client.Invoking(x => x.CreateAuthorizedClient()).Should().ThrowAsync<TimeoutException>();
        }

        private void SetCachedToken(LearnsterToken learnsterToken)
        {
            var field = typeof(LearnsterHttpClientFactory)
                .GetField("_cachedToken", BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, learnsterToken);
        }

        private void SetupAutoResetEvent(bool isReleased)
        {
            var autoResetEventField = typeof(LearnsterHttpClientFactory)
                .GetField("AutoResetEvent", BindingFlags.NonPublic | BindingFlags.Static);
            var autoResetEvent = (AutoResetEvent) autoResetEventField.GetValue(null);
            autoResetEvent.WaitOne(1);

            if (isReleased)
                autoResetEvent.Set();
            else
                autoResetEvent.WaitOne(100);

        }
    }
}