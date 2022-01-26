using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using JAG.Learnster.APIClient.Converters;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests
{
    public class HttpClientExtensionsTests
    {
        [Theory]
        [InlineData("test", TestEnum.OneWorldTest)]
        [InlineData("test-with-dash", TestEnum.TestWithDash)]
        [InlineData("TestWithoutNumber", TestEnum.TestWithoutNumber)]
        [InlineData("test with space", TestEnum.TestWithSpace)]
        [InlineData("TestWithoutEnumMember", TestEnum.TestWithoutEnumMember)]
        public void DeserializeContent_EnumAsString_ReturnEnum(string value, TestEnum expectedEnum)
        {
            // Arrange
            var str = $"{{\"Enum\":\"{value}\"}}";

            // Act
            var result = JsonSerializer.Deserialize<ClassWithTestEnum>(str);

            // Assert
            result.Should().NotBeNull();
            result!.Enum.Should().Be(expectedEnum);
        }
        
        [Theory]
        [InlineData("test", TestEnum.OneWorldTest)]
        [InlineData("test-with-dash", TestEnum.TestWithDash)]
        [InlineData("TestWithoutNumber", TestEnum.TestWithoutNumber)]
        [InlineData("test with space", TestEnum.TestWithSpace)]
        [InlineData("TestWithoutEnumMember", TestEnum.TestWithoutEnumMember)]
        [InlineData("FakeString", null)]
        public void DeserializeContent_NullableEnumWithDash_ReturnEnum(string value, TestEnum? expectedEnum)
        {
            // Arrange
            var str = $"{{\"Enum\":\"{value}\"}}";

            // Act
            var result = JsonSerializer.Deserialize<ClassWithNullableTestEnum>(str);

            // Assert
            result.Should().NotBeNull();
            result!.Enum.Should().Be(expectedEnum);
        }
        
        [Fact]
        public void DeserializeContent_Number_ReturnEnum()
        {
            // Arrange
            var expectedEnum = TestEnum.OneWorldTest;
            var str = $"{{\"Enum\":{(int) expectedEnum}}}";

            // Act
            var result = JsonSerializer.Deserialize<ClassWithNullableTestEnum>(str);

            // Assert
            result.Should().NotBeNull();
            result!.Enum.Should().Be(expectedEnum);
        }
        
        [Fact]
        public void DeserializeContent_Null_ReturnNull()
        {
            // Arrange
            var str = $"{{\"Enum\":null}}";

            // Act
            var result = JsonSerializer.Deserialize<ClassWithNullableTestEnum>(str);

            // Assert
            result.Should().NotBeNull();
            result!.Enum.Should().Be(null);
        }
        
        private class ClassWithTestEnum
        {
            [JsonConverter(typeof(CustomizableJsonStringEnumConverter<TestEnum>))]
            public TestEnum Enum { get; set; }
        }
        
        private class ClassWithNullableTestEnum
        {
            [JsonConverter(typeof(CustomizableJsonStringEnumConverter<TestEnum?>))]
            public TestEnum? Enum { get; set; }
        }
        
        public enum TestEnum
        {
            [EnumMember(Value = "test")]
            OneWorldTest = 1,
            
            [EnumMember(Value = "test with space")]
            TestWithSpace = 2,

            [EnumMember(Value = "test-with-dash")]
            TestWithDash = 3,

            TestWithoutEnumMember = 4,
            
            TestWithoutNumber
        }
    }
}