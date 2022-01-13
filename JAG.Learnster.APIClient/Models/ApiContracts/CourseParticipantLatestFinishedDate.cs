using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicCourseParticipantLatestFinishedDate
    /// </summary>
    public class CourseParticipantLatestFinishedDate
    {
        /// <summary>
        /// Gets or Sets SessionId
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or Sets LatestFinishedDate
        /// </summary>
        [JsonPropertyName("latest_finished_date")]
        public string LatestFinishedDate { get; set; }
    }
}
