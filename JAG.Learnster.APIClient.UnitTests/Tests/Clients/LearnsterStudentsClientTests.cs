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
using JAG.Learnster.APIClient.Models.Requests.Student;
using JAG.Learnster.APIClient.UnitTests.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Clients
{
    public class LearnsterStudentsClientTests : BaseTest
    {
        private readonly LearnsterStudentsClient _learnsterStudentsClient;

        public LearnsterStudentsClientTests()
        {
            var learnsterHttpClientFactoryMock = HttpClientHelper
                .CreateLearnsterHttpClientFactoryMock(HttpClientHandlerMock);
            
            OptionMock.Setup(x => x.Value).Returns(LearnsterOptions);

            _learnsterStudentsClient = new LearnsterStudentsClient(
                OptionMock.Object, 
                NullLogger<LearnsterStudentsClient>.Instance,
                learnsterHttpClientFactoryMock.Object);
        }
        
        [Fact]
        public async Task GetAll_Success_ReturnSessions()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<VendorStudent>(5).ToArray();
            var sessionsResponseList = new ResponseList<VendorStudent>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterStudentsClient.GetAll();
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().NotBeEmpty();
            sessions.Should().BeEquivalentTo(expectedSessions);
        }

        [Fact]
        public async Task GetAll_EmptyCollection_ReturnSessions()
        {
            // Arrange
            var sessionsResponseList = new ResponseList<VendorStudent>()
            {
                Count = 0,
                Results = Array.Empty<VendorStudent>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterStudentsClient.GetAll();
            
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
            await _learnsterStudentsClient.Invoking(x => x.GetAll()).Should().ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task SearchStudents_Success_ReturnStudents()
        {
            // Arrange
            var expectedSessions = new Fixture().CreateMany<VendorStudent>(5).ToArray();
            var sessionsResponseList = new ResponseList<VendorStudent>()
            {
                Count = expectedSessions.Count(),
                Results = expectedSessions
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterStudentsClient.SearchStudents(string.Empty);
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().NotBeEmpty();
            sessions.Should().BeEquivalentTo(expectedSessions);
        }

        [Fact]
        public async Task SearchStudents_EmptyCollection_ReturnEmptyCollection()
        {
            // Arrange
            var sessionsResponseList = new ResponseList<VendorStudent>()
            {
                Count = 0,
                Results = Array.Empty<VendorStudent>()
            };
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, sessionsResponseList);
            
            // Act
            var sessions = await _learnsterStudentsClient.SearchStudents(string.Empty);
            
            // Assert
            sessions.Should().NotBeNull();
            sessions.Should().BeEmpty();
        }
        
        [Fact]
        public async Task SearchStudents_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterStudentsClient.Invoking(x => x.SearchStudents(string.Empty)).Should().ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task CreateStudent_Success_ReturnStudent()
        {
            // Arrange
            var createUserRequest = new Fixture().Create<CreateStudentRequest>();
            var expectedUser = new Fixture().Create<VendorStudent>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedUser);

            // Act
            var student = await _learnsterStudentsClient.CreateStudent(createUserRequest);
            
            // Assert
            student.Should().NotBeNull();
            student.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task CreateStudent_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.CreateStudent(new Fixture().Create<CreateStudentRequest>()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task UpdateStudent_Success_ReturnStudent()
        {
            // Arrange
            var expectedUser = new Fixture().Create<VendorStudent>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedUser);

            // Act
            var student = await _learnsterStudentsClient.UpdateStudent(new Fixture()
                .Create<UpdateStudentRequest>());
            
            // Assert
            student.Should().NotBeNull();
            student.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task UpdateStudent_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.UpdateStudent(new Fixture().Create<UpdateStudentRequest>()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task UpdateStudent_NotFound_ReturnNotFoundException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.NotFound);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.UpdateStudent(new Fixture().Create<UpdateStudentRequest>()))
                .Should()
                .ThrowAsync<NotFoundLearnsterException>();
        }
        
        [Fact]
        public async Task UpdateStudent_StudentIdIsEmpty_ReturnArgumentException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            var studentWithEmptyGuid = new Fixture()
                .Build<UpdateStudentRequest>()
                .Without(x => x.StudentId)
                .Create();
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.UpdateStudent(studentWithEmptyGuid))
                .Should()
                .ThrowAsync<ArgumentException>();
        }
        
        [Fact]
        public async Task DeleteStudent_Success_NoException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.OK);
            
            // Act
            await _learnsterStudentsClient.DeleteStudent(Guid.Empty);
        }

        [Fact]
        public async Task DeleteStudent_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.DeleteStudent(Guid.Empty))
                .Should()
                .ThrowAsync<Exception>();
        }

        [Fact]
        public async Task ActivateStudent_Success_ReturnStudent()
        {
            // Arrange
            var expectedUser = new Fixture().Create<VendorStudent>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedUser);

            // Act
            var student = await _learnsterStudentsClient.ActivateStudent(Guid.NewGuid());
            
            // Assert
            student.Should().NotBeNull();
            student.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task ActivateStudent_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.ActivateStudent(Guid.NewGuid()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task ActivateStudent_NotFound_ReturnNotFoundException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.NotFound);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.ActivateStudent(Guid.NewGuid()))
                .Should()
                .ThrowAsync<NotFoundLearnsterException>();
        }
        
        [Fact]
        public async Task ActivateStudent_StudentIdIsEmpty_ReturnArgumentException()
        {
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.ActivateStudent(Guid.Empty))
                .Should()
                .ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task DeactivateStudent_Success_ReturnStudent()
        {
            // Arrange
            var expectedUser = new Fixture().Create<VendorStudent>();
            HttpClientHandlerMock.SetupSend(HttpStatusCode.OK, expectedUser);

            // Act
            var student = await _learnsterStudentsClient.DeactivateStudent(Guid.NewGuid());
            
            // Assert
            student.Should().NotBeNull();
            student.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task DeactivateStudent_InternalServerError_ReturnException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.InternalServerError);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.ActivateStudent(Guid.NewGuid()))
                .Should()
                .ThrowAsync<Exception>();
        }
        
        [Fact]
        public async Task DeactivateStudent_NotFound_ReturnNotFoundException()
        {
            // Arrange
            HttpClientHandlerMock.SetupSendWithEmptyResponse(HttpStatusCode.NotFound);
            
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.ActivateStudent(Guid.NewGuid()))
                .Should()
                .ThrowAsync<NotFoundLearnsterException>();
        }
        
        [Fact]
        public async Task DeactivateStudent_StudentIdIsEmpty_ReturnArgumentException()
        {
            // Act
            await _learnsterStudentsClient
                .Invoking(x => x.ActivateStudent(Guid.Empty))
                .Should()
                .ThrowAsync<ArgumentException>();
        }
    }
}