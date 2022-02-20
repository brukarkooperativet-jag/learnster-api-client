using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models.Requests.Team;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
    public class TeamClientTests : BaseClientTests
    {
        private readonly ILearnsterTeamClient _client;

        public TeamClientTests()
        {
            _client = ServiceProvider.GetRequiredService<ILearnsterTeamClient>();
        }
        
        [Fact]
        public async Task GetAll_Success_ReturnTeams()
        {
            // Act
            var team = await _client.GetAll();

            // Assert
            team.Should().NotBeEmpty();
            team.Count.Should().BeGreaterOrEqualTo(1);
        }

        [Fact]
        public async Task GetTeam_Success_ReturnTeam()
        {
            // Arrange
            var expectedTeamId = TestLearnsterOptions.TeamId;
            
            // Act
            var team = await _client.GetTeam(expectedTeamId);

            // Assert
            team.Should().NotBeNull();
            team.Id.Should().Be(expectedTeamId);
        }

        [Fact]
        public async Task GetTeamByName_Success_ReturnTeam()
        {
            // Arrange
            var expectedTeamName = TestLearnsterOptions.TeamName;
            
            // Act
            var team = await _client.GetTeamByName(expectedTeamName);

            // Assert
            team.Should().NotBeNull();
            team.Name.Should().BeEquivalentTo(expectedTeamName);
        }
        
        [Fact]
        public async Task SearchTeamByName_Success_ReturnTeam()
        {
            // Arrange
            var expectedTeamName = TestLearnsterOptions.TeamName;
            
            // Act
            var teams = await _client.SearchTeamByName(expectedTeamName);

            // Assert
            teams.Should().NotBeNull();
            teams.Count.Should().Be(1);
            teams.First().Name.Should().BeEquivalentTo(expectedTeamName);
        }

        [Fact]
        public async Task CreateTeam_Success_ReturnCreatedTeam()
        {
            // Arrange
            var currentTimeString = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var createTeamRequest = new CreateTeamRequest()
            {
                Name = $"IntegrationTest_{currentTimeString}",
                Description = nameof(CreateTeam_Success_ReturnCreatedTeam),
                AllowDiscussion = true,
                ControlledByIntegration = true
            };
            
            // Act
            var team = await _client.CreateTeam(createTeamRequest);

            // Assert
            try
            {
                team.Should().NotBeNull();
                team.Name.Should().Be(createTeamRequest.Name);
                team.Description.Should().Be(createTeamRequest.Description);
                team.AllowDiscussion.Should().Be(createTeamRequest.AllowDiscussion);
                team.ControlledByIntegration.Should().Be(createTeamRequest.ControlledByIntegration);
            }
            finally
            {
                await _client.DeleteTeam(team.Id);
            }
        }

        [Fact]
        public async Task DeleteTeam_Success_DeleteTeamInLearnster()
        {
            // Arrange
            var currentTimeString = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var createTeamRequest = new CreateTeamRequest()
            {
                Name = $"IntegrationTest_{currentTimeString}",
                Description = nameof(DeleteTeam_Success_DeleteTeamInLearnster),
                AllowDiscussion = true,
                ControlledByIntegration = true
            };
            var createdTeam = await _client.CreateTeam(createTeamRequest);

            // Act
            await _client.DeleteTeam(createdTeam.Id);
            
            // Assert
            var teamAfterDeleting = await _client.SearchTeamByName(createTeamRequest.Name);
            teamAfterDeleting.Should().BeEmpty();
        }
        
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task AddMember_Success_AddAndReturnMemberList(bool isManager)
        {
            // Arrange
            var studentIdToAdd = TestLearnsterOptions.StudentForUpdating.StudentId;
            var teamForUpdatingId = TestLearnsterOptions.TeamId;

            // Act
            var teamMemberResult = await _client.AddMember(teamForUpdatingId, studentIdToAdd, isManager);

            // Assert
            try
            {
                var student = isManager
                    ? teamMemberResult.Managers.FirstOrDefault(x => x.Id == studentIdToAdd)
                    : teamMemberResult.Members.FirstOrDefault(x => x.Id == studentIdToAdd);
                student.Should().NotBeNull();
            }
            finally
            {
                await _client.RemoveMember(teamForUpdatingId, studentIdToAdd);
            }
        }
        
        [Fact]
        public async Task RemoveMember_Success_AddAndReturnMemberList()
        {
            // Arrange
            var studentIdToAdd = TestLearnsterOptions.StudentForUpdating.StudentId;
            var teamForUpdatingId = TestLearnsterOptions.TeamId;
            await _client.AddMember(teamForUpdatingId, studentIdToAdd);

            // Act
            var removeResult = await _client.RemoveMember(teamForUpdatingId, studentIdToAdd);
            
            // Assert
            removeResult.Members.Where(x => x.Id == studentIdToAdd).Should().BeEmpty();
            removeResult.Managers.Where(x => x.Id == studentIdToAdd).Should().BeEmpty();
        }
    }
}