using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.UnitTests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Clients
{
    public class LearnsterSessionsClientTests : BaseTest
    {
        private readonly LearnsterSessionsClient _learnsterSessionsClient;

        public LearnsterSessionsClientTests()
        {
            var learnsterHttpClientFactoryMock = HttpClientHelper.CreateLearnsterHttpClientFactoryMock(HttpClientHandlerMock);

            _learnsterSessionsClient = new LearnsterSessionsClient(
                NullLogger<LearnsterSessionsClient>.Instance,
                OptionMock.Object, 
                learnsterHttpClientFactoryMock.Object);
        }

        [Fact]
        public async Task GetAll_Success_ReturnSessions()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<SessionShortWithAvatar>(5).ToArray();
            var sessionsResponseList = new ResponseList<SessionShortWithAvatar>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterSessionsClient.GetAll();
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().NotBeEmpty();
            sessions.Should().BeEquivalentTo(expectedSessions);
        }
        
        [Fact]
        public async Task GetAll_EmptyCollection_ReturnSessions()
        {
            // Arrange
            var sessionsResponseList = new ResponseList<SessionShortWithAvatar>()
            {
                Count = 0,
                Results = Array.Empty<SessionShortWithAvatar>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterSessionsClient.GetAll();
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().BeEmpty();
        }
        
        [Fact]
        public async Task GetAll_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterSessionsClient.Invoking(x => x.GetAll()).Should().ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task GetStudentSessions_Success_ReturnSessions()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<UserCourseParticipant>(5).ToArray();
            var sessionsResponseList = new ResponseList<UserCourseParticipant>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterSessionsClient.GetStudentSessions(Guid.Empty);
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().NotBeEmpty();
            sessions.Should().BeEquivalentTo(expectedSessions);
        }
        
        [Fact]
        public async Task GetStudentSessions_EmptyCollection_ReturnSessions()
        {
            // Arrange
            var sessionsResponseList = new ResponseList<UserCourseParticipant>()
            {
                Count = 0,
                Results = Array.Empty<UserCourseParticipant>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterSessionsClient.GetStudentSessions(Guid.Empty);
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().BeEmpty();
        }
        
        [Fact]
        public async Task GetStudentSessions_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterSessionsClient.Invoking(x => x.GetStudentSessions(Guid.Empty)).Should().ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task GetAvailableForStudent_Success_ReturnSessions()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<PossibleChoicesSession>(5).ToArray();
            var sessionsResponseList = new ResponseList<PossibleChoicesSession>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterSessionsClient.GetAvailableForStudent(Guid.Empty);
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().NotBeEmpty();
            sessions.Should().BeEquivalentTo(expectedSessions);
        }
        
        [Fact]
        public async Task GetAvailableForStudent_EmptyCollection_ReturnSessions()
        {
            // Arrange
            var sessionsResponseList = new ResponseList<PossibleChoicesSession>()
            {
                Count = 0,
                Results = Array.Empty<PossibleChoicesSession>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterSessionsClient.GetAvailableForStudent(Guid.Empty);
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().BeEmpty();
        }
        
        [Fact]
        public async Task GetAvailableForStudent_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterSessionsClient.Invoking(x => x.GetAvailableForStudent(Guid.Empty)).Should().ThrowAsync<Exception>();
        }
    }
}