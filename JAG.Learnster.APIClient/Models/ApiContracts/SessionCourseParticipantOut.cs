using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionCourseParticipantOut
    /// </summary>
    public class SessionCourseParticipantOut
    {
        /// <summary>
        /// Gets or Sets Passed
        /// </summary>
        [JsonPropertyName("passed")]
        public Enums.PassedEnum? Passed { get; set; }

        /// <summary>
        /// Gets or Sets ManualApproval
        /// </summary>
        [JsonPropertyName("manual_approval")]
        public ManualApprovalEnum? ManualApproval { get; set; }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [JsonPropertyName("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets FinishedDate
        /// </summary>
        [JsonPropertyName("finished_date")]
        public DateTime? FinishedDate { get; set; }

        /// <summary>
        /// Gets or Sets VendorStudent
        /// </summary>
        [JsonPropertyName("vendor_student")]
        public VendorStudentName VendorStudent { get; set; }

        /// <summary>
        /// Gets or Sets LastLogin
        /// </summary>
        [JsonPropertyName("last_login")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Gets or Sets Progress
        /// </summary>
        [JsonPropertyName("progress")]
        public string Progress { get; set; }


        /// <summary>
        /// Gets or Sets AttendedCount
        /// </summary>
        [JsonPropertyName("attended_count")]
        public int? AttendedCount { get; set; }

        /// <summary>
        /// Gets or Sets TotalDaysForAttendance
        /// </summary>
        [JsonPropertyName("total_days_for_attendance")]
        public int? TotalDaysForAttendance { get; set; }

        /// <summary>
        /// Gets or Sets Certification
        /// </summary>
        [JsonPropertyName("certification")]
        public RecurringCertification Certification { get; set; }
    }
}
