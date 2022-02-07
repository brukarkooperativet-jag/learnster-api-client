using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Exceptions;
using JAG.Learnster.APIClient.Models;
using JAG.Learnster.APIClient.Models.ApiContracts;
using JAG.Learnster.APIClient.Models.Requests.Team;
using JAG.Learnster.APIClient.UnitTests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Clients
{
    public class LearnsterTeamClientTest : BaseTest
    {
        private readonly LearnsterTeamClient _teamClient;

        public LearnsterTeamClientTest()
        {
            var learnsterHttpClientFactoryMock = HttpClientHelper.CreateLearnsterHttpClientFactoryMock(HttpClientHandlerMock);

            _teamClient = new LearnsterTeamClient(
                OptionMock.Object,
                NullLogger<LearnsterTeamClient>.Instance, 
                learnsterHttpClientFactoryMock.Object);
        }
        
        [Fact]
        public async Task GetAll_Success_ReturnSessions()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<Team>(5).ToArray();
            var sessionsResponseList = new ResponseList<Team>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var teams = await _teamClient.GetAll();
            
            // Assert
            teams.Should().NotBeNull();
            teams.Should().NotBeEmpty();
            teams.Should().BeEquivalentTo(expectedSessions);
        }

        [Fact]
        public async Task GetAll_EmptyCollection_ReturnSessions()
        {
            // Arrange
            var responseList = new ResponseList<Team>()
            {
                Count = 0,
                Results = Array.Empty<Team>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, responseList);
            
            // Act
            var teams = await _teamClient.GetAll();
            
            // Assert
            teams.Should().NotBeNull();
            teams.Should().BeEmpty();
        }
        
        [Fact]
        public async Task GetAll_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient.Invoking(x => x.GetAll()).Should().ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task GetTeam_Success_ReturnSessions()
        {
            // Arrange
            var expectedTeam = new Fixture().Create<Team>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedTeam);
            
            // Act
            var team = await _teamClient.GetTeam(Guid.NewGuid());
            
            // Assert
            team.Should().NotBeNull();
            team.Should().BeEquivalentTo(expectedTeam);
        }

        [Fact]
        public async Task GetTeam_NotFound_ReturnNotFoundException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.NotFound);
            
            // Act
            await _teamClient
                .Invoking(x => x.GetTeam(Guid.NewGuid()))
                .Should()
                .ThrowAsync<NotFoundLearnsterException>();
        }
        
        [Fact]
        public async Task GetTeam_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.GetTeam(Guid.NewGuid()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task SearchTeamByName_Success_ReturnSessions()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<Team>(5).ToArray();
            var sessionsResponseList = new ResponseList<Team>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var teams = await _teamClient.SearchTeamByName(Fixture.Create<string>());
            
            // Assert
            teams.Should().NotBeNull();
            teams.Should().NotBeEmpty();
            teams.Should().BeEquivalentTo(expectedSessions);
        }

        [Fact]
        public async Task SearchTeamByName_EmptyCollection_ReturnSessions()
        {
            // Arrange
            var responseList = new ResponseList<Team>()
            {
                Count = 0,
                Results = Array.Empty<Team>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, responseList);
            
            // Act
            var teams = await _teamClient.SearchTeamByName(Fixture.Create<string>());
            
            // Assert
            teams.Should().NotBeNull();
            teams.Should().BeEmpty();
        }
        
        [Fact]
        public async Task SearchTeamByName_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.SearchTeamByName(Fixture.Create<string>()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task GetTeamByName_Success_ReturnTeam()
        {
            // Arrange
            var expectedTeam = Fixture.Create<Team>();
            var sessionsResponseList = new ResponseList<Team>()
            {
                Count = 1,
                Results = new [] {expectedTeam}
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var team = await _teamClient.GetTeamByName(expectedTeam.Name);
            
            // Assert
            team.Should().NotBeNull();
            team.Should().BeEquivalentTo(expectedTeam);
        }

        [Fact]
        public async Task GetTeamByName_PersonIsNoptExist_ReturnNull()
        {
            // Arrange
            var responseList = new ResponseList<Team>()
            {
                Count = 0,
                Results = Array.Empty<Team>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, responseList);
            
            // Act
            var teams = await _teamClient.GetTeamByName(Fixture.Create<string>());
            
            // Assert
            teams.Should().BeNull();
        }
        
        [Fact]
        public async Task GetTeamByName_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.GetTeamByName(Fixture.Create<string>()))
                .Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task CreateTeam_Success_ReturnNewTeam()
        {
            // Arrange
            var creatingTeam = Fixture.Create<CreateTeamRequest>();
            var expectedResult = Fixture.Create<Team>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedResult);

            // Act
            var teams = await _teamClient.CreateTeam(creatingTeam);
            
            // Assert
            teams.Should().NotBeNull();
            teams.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public async Task CreateTeam_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.CreateTeam(Fixture.Create<CreateTeamRequest>()))
                .Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task DeleteTeam_Success_NoException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, new object());

            // Act
            await _teamClient.DeleteTeam(Fixture.Create<Guid>());
        }
        
        [Fact]
        public async Task DeleteTeam_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.DeleteTeam(Fixture.Create<Guid>()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task AddMember_Success_ReturnResult()
        {
            // Arrange
            var expectedResult = Fixture.Create<AddTeamMemberResult>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedResult);

            // Act
            var result = await _teamClient.AddMember(Fixture.Create<Guid>(), Fixture.Create<Guid>());
            
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public async Task AddMember_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.AddMember(Fixture.Create<Guid>(), Fixture.Create<Guid>()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        
        [Fact]
        public async Task RemoveMember_Success_ReturnResult()
        {
            // Arrange
            var expectedResult = Fixture.Create<RemoveTeamMemberResult>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedResult);

            // Act
            var result = await _teamClient.RemoveMember(Fixture.Create<Guid>(), Fixture.Create<Guid>());
            
            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Fact]
        public async Task RemoveMember_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _teamClient
                .Invoking(x => x.RemoveMember(Fixture.Create<Guid>(), Fixture.Create<Guid>()))
                .Should()
                .ThrowAsync<Exception>();
        }
    }
}