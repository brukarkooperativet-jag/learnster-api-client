using System;
using JetBrains.Annotations;

namespace JAG.Learnster.APIClient.IntegrationTests.Options
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class TestLearnsterOptions
    {
        public const string SectionName = "TestLearnsterOptions";
        
        public TestStudentOptions StudentWithCourses { get; set; }
        public TestStudentOptions StudentWithFinishedCourses { get; set; }
        public TestStudentOptions StudentForUpdating { get; set; }
        
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public Guid TeamForUpdatingGuid { get; set; }
    }
    
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public class TestStudentOptions
    {
        public Guid? VendorId { get; set; }
        public Guid StudentId { get; set; }
    }
}