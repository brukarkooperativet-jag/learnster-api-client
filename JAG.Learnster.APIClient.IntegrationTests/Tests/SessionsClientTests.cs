using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
    public class SessionsClientTests : BaseClientTests
    {
        private readonly ISessionsClient _sessionsClient;

        public SessionsClientTests()
        {
            _sessionsClient = new SessionsClient(
                AuthClient,
                NullLogger<SessionsClient>.Instance,
                LearnsterOptionsMock.Object);
        }

        [Fact]
        public async Task GetAllAvailableSessions_SessionsIsExist_ReturnList()
        {
            // Act
            var sessionList = await _sessionsClient
                .GetAvailableForStudent(TestLearnsterOptions.StudentWithCourses.StudentId);

            // Assert
            sessionList.Should().NotBeNull();
            sessionList.Results.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetAll_ReturnSessions()
        {
            // Act
            var sessionList = await _sessionsClient.GetAll();
            
            // Assert
            sessionList.Should().NotBeNull();
            sessionList.Count.Should().BeGreaterThan(0);
        }
    }
}