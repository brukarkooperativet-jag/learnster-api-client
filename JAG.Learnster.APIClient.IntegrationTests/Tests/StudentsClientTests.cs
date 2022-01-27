using System;
using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Clients;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models.Requests;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class StudentsClientTests : BaseClientTests
	{
		private readonly LearnsterStudentsClient _client;

		public StudentsClientTests()
		{
			_client = (LearnsterStudentsClient) ServiceProvider.GetRequiredService<ILearnsterStudentsClient>();
		}

		[Fact]
		public async Task GetAllStudents_Success()
		{
			// Act
			var students = await _client.GetAll();
			
			// Assert
			students.Should().NotBeNull();
		}
		
		[Fact]
		public async Task CreateStudent_NewUser_ReturnUser()
		{
			// Arrange
			var currentTimeString = DateTimeOffset.Now.ToUnixTimeMilliseconds();
			var newStudent = new CreateUserRequest()
			{
				User = new CreateStudentRequest()
				{
					Email = $"user-{currentTimeString}@integrated.test",
					FirstName = $"User_{currentTimeString}",
					LastName = "Test"
				},
				
			};
			
			// Act
			var createdStudent = await _client.CreateStudent(newStudent);
			
			// Assert
			createdStudent.Should().NotBeNull();
			createdStudent.User.Email.Should().Be(newStudent.User.Email);
			createdStudent.Id.Should().NotBeNull();
			createdStudent.User.FirstName.Should().Be(newStudent.User.FirstName);
			createdStudent.User.LastName.Should().Be(newStudent.User.LastName);
			
			// TODO: Add method to clean up all test data
			// Clean up
			// ReSharper disable once PossibleInvalidOperationException
			await _client.DeleteStudent(createdStudent.Id.Value);
		}
	}
}