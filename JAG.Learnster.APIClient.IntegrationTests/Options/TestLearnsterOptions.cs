using System;

namespace JAG.Learnster.APIClient.IntegrationTests.Options
{
    public class TestLearnsterOptions
    {
        public const string SECTION_NAME = "TestLearnsterOptions";
        
        public TestStudentOptions StudentWithCourses { get; set; }
    }
    
    public class TestStudentOptions
    {
        public Guid? VendorId { get; set; }
        public Guid StudentId { get; set; }
    }
}