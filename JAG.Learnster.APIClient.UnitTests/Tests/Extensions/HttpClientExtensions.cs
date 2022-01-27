using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using JAG.Learnster.APIClient.Extensions;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Extensions
{
    public class HttpClientExtensions
    {
        [Fact]
        public async Task DeserializeContent_ReturnModel()
        {
            // Arrange
            var model = new Fixture().Create<TestClass>();
            var stringData = JsonSerializer.Serialize(model);
            var responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(stringData)
            };

            // Act
            var deserializedModel = await responseMessage.DeserializeContent<TestClass>();

            // Assert
            deserializedModel.Should().BeEquivalentTo(model);
        }
        
        private class TestClass
        {
            public int Number { get; set; } 
            public string String { get; set; } 
        }
    }
}