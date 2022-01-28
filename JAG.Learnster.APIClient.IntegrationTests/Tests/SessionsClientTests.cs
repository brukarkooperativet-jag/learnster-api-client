using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
    public class SessionsClientTests : BaseClientTests
    {
        private readonly LearnsterSessionsClient _learnsterSessionsClient;

        public SessionsClientTests()
        {
            _learnsterSessionsClient = (LearnsterSessionsClient) ServiceProvider.GetRequiredService<ILearnsterSessionsClient>();

        }

        [Fact]
        public async Task GetAllAvailableSessions_SessionsIsExist_ReturnList()
        {
            // Act
            var sessionList = await _learnsterSessionsClient
                .GetAvailableForStudent(TestLearnsterOptions.StudentWithCourses.StudentId);

            // Assert
            sessionList.Should().NotBeNull();
            sessionList.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetAll_ReturnSessions()
        {
            // Act
            var sessionList = await _learnsterSessionsClient.GetAll();
            
            // Assert
            sessionList.Should().NotBeNull();
            sessionList.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public async Task GetStudentSessions_UserHasAssignedSessions_ReturnSessions()
        {
            // Act
            var sessionList = await _learnsterSessionsClient
                .GetStudentSessions(TestLearnsterOptions.StudentWithCourses.StudentId);
            
            // Assert
            sessionList.Should().NotBeNull();
            sessionList.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public async Task GetStudentSessionsHistory_UserHasFinishedSessions_ReturnSessions()
        {
            // Act
            var sessionList = await _learnsterSessionsClient
                .GetStudentSessionsHistory(TestLearnsterOptions.StudentWithCourses.StudentId);
            
            // Assert
            sessionList.Should().NotBeNull();
            sessionList.Count.Should().BeGreaterThan(0);
        }
    }
}