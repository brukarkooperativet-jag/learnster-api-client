using System;
using System.Threading.Tasks;
using FluentAssertions;
using JAG.Learnster.APIClient.Interfaces;
using JAG.Learnster.APIClient.Models.Requests.Student;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JAG.Learnster.APIClient.IntegrationTests.Tests
{
	public class StudentsClientTests : BaseClientTests
	{
		private readonly ILearnsterStudentsClient _client;

		public StudentsClientTests()
		{
			_client = ServiceProvider.GetRequiredService<ILearnsterStudentsClient>();
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
			var newStudent = new CreateStudentRequest()
			{
				User = new CreateUserRequest()
				{
					Email = $"user-{currentTimeString}@integrated.test",
					FirstName = $"User_{currentTimeString}",
					LastName = "Test",
					PersonalId = Guid.NewGuid().ToString()
				},
			};

			// Act
			var createdStudent = await _client.CreateStudent(newStudent);

			try
			{
				// Assert
				createdStudent.Should().NotBeNull();
				createdStudent.User.Email.Should().Be(newStudent.User.Email);
				createdStudent.Id.Should().NotBeNull();
				createdStudent.User.FirstName.Should().Be(newStudent.User.FirstName);
				createdStudent.User.LastName.Should().Be(newStudent.User.LastName);
				createdStudent.User.PersonalId.Should().Be(newStudent.User.PersonalId);
			}
			finally
			{
				// Clean up
				await _client.DeleteStudent(createdStudent.Id!.Value);
			}
		}
		
		[Fact]
		public async Task UpdateStudent_UserExist_ReturnUser()
		{
			// Arrange
			var currentTimeString = DateTimeOffset.Now.ToUnixTimeMilliseconds();
			var updateStudent = new UpdateStudentRequest()
			{
				StudentId = TestLearnsterOptions.StudentForUpdating.StudentId,
				User = new UpdateUserRequest()
				{
					Email = $"user-{currentTimeString}@integrated.test",
					FirstName = $"UserForUpdating_{currentTimeString}",
					LastName = $"User_{currentTimeString}"
				}
			};
			
			// Act
			var createdStudent = await _client.UpdateStudent(updateStudent);
			
			// Assert
			createdStudent.Should().NotBeNull();
			createdStudent.User.Email.Should().Be(updateStudent.User.Email);
			createdStudent.User.FirstName.Should().Be(updateStudent.User.FirstName);
			createdStudent.User.LastName.Should().Be(updateStudent.User.LastName);
			createdStudent.User.PersonalId.Should().NotBeNullOrWhiteSpace();
		}
		
		[Fact]
		public async Task ActivateAndDeactivateStudent_UserExist_ReturnUser()
		{
			// Arrange + checking start condition, Set "default" active state
			var student = await _client.ActivateStudent(TestLearnsterOptions.StudentForUpdating.StudentId);
			student.Should().NotBeNull();
			student.Active.Should().BeTrue();
			
			// Act #1, deactivate
			var deactivatedStudent = await _client.DeactivateStudent(TestLearnsterOptions.StudentForUpdating.StudentId);
			
			// Assert #1
			deactivatedStudent.Should().NotBeNull();
			deactivatedStudent.Active.Should().BeFalse("Student is deactivated");
			
			// Act #2, Activate
			var activatedStudent = await _client.ActivateStudent(TestLearnsterOptions.StudentForUpdating.StudentId);

			// Assert #2
			activatedStudent.Should().NotBeNull();
			activatedStudent.Active.Should().BeTrue("Student is activated");
		}
	}
}