using System;
using FluentAssertions;
using JAG.Learnster.APIClient.Services;
using Xunit;

namespace JAG.Learnster.APIClient.UnitTests.Tests.Services
{
    public class LearnsterUrlBuilderTests : BaseTest
    {
        private readonly LearnsterUrlBuilder _learnsterUrlBuilder;

        private const string TestUrl = "https://test-url.org";
        private const string VendorName = "some-vendor";
        
        public LearnsterUrlBuilderTests()
        {
            _learnsterUrlBuilder = new LearnsterUrlBuilder(OptionMock.Object);
            
            LearnsterOptions.Url = new Uri(TestUrl);
            LearnsterOptions.VendorName = VendorName;
        }
        
        [Fact]
        public void BuildImageUrl_Success_ReturnUrl()
        {
            // Act
            var imageUrl = _learnsterUrlBuilder.BuildImageUrl("someTestRelativeUrl");

            // Assert
            imageUrl.Should().BeEquivalentTo(new Uri($"{TestUrl}/someTestRelativeUrl"));
        }
        
        [Fact]
        public void BuildCourseUrl_Success_ReturnUrl()
        {
            // Arrange
            var courseGuid = Guid.NewGuid();
            
            // Act
            var imageUrl = _learnsterUrlBuilder.BuildCourseUrl(courseGuid);

            // Assert
            imageUrl.Should().BeEquivalentTo(new Uri($"{TestUrl}/{VendorName}/sessions/{courseGuid }"));
        }
    }
}