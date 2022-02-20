using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicUserStudentHistory
    /// </summary>
    public class StudentHistory
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets VendorName
        /// </summary>
        [JsonPropertyName("vendor_name")]
        public string VendorName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Spent Time in Hours
        /// </summary>
        /// <value>Spent Time in Hours</value>
        [JsonPropertyName("spent_time")]
        public decimal? SpentTime { get; set; }

        /// <summary>
        /// Gets or Sets FinishDate
        /// </summary>
        [JsonPropertyName("finish_date")]
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// Gets or Sets CourseParticipant
        /// </summary>
        [JsonPropertyName("course_participant")]
        public SessionParticipant SessionParticipant { get; set; }
    }
}
