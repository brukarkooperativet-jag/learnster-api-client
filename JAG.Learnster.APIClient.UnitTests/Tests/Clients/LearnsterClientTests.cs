using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Interfaces;
using Moq;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Clients
{
    public class LearnsterClientTests
    {
        private readonly LearnsterClient _learnsterClient;

        public LearnsterClientTests()
        {
            var learnsterSessionsClientMock = new Mock<ILearnsterSessionsClient>();
            var learnsterStudentsClientMock = new Mock<ILearnsterStudentsClient>();
            var learnsterTeamClientMock = new Mock<ILearnsterTeamClient>();

            _learnsterClient = new LearnsterClient(
                learnsterSessionsClientMock.Object,
                learnsterStudentsClientMock.Object,
                learnsterTeamClientMock.Object);
        }

        [Fact]
        public void GetSessionClient_Success_ReturnClient()
        {
            // Act
            var sessionsClient = _learnsterClient.Sessions;
            
            // Assert
            sessionsClient.Should().NotBeNull();
        }
        
        [Fact]
        public void GetStudentClient_Success_ReturnClient()
        {
            // Act
            var studentsClient = _learnsterClient.Students;
            
            // Assert
            studentsClient.Should().NotBeNull();
        }

        [Fact]
        public void GetTeamClient_Success_ReturnClient()
        {
            // Act
            var studentsClient = _learnsterClient.Teams;
            
            // Assert
            studentsClient.Should().NotBeNull();
        }
    }
}