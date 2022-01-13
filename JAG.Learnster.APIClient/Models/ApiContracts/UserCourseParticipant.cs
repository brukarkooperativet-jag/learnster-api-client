using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicUserCourseParticipant
    /// </summary>
    public class UserCourseParticipant
    {
        /// <summary>
        /// Gets or Sets Passed
        /// </summary>
        [JsonPropertyName("passed")]
        public PassedEnum? Passed { get; set; }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Progress
        /// </summary>
        [JsonPropertyName("progress")]
        public string Progress { get; set; }

        /// <summary>
        /// Gets or Sets Session
        /// </summary>
        [JsonPropertyName("session")]
        public UserSession Session { get; set; }

        /// <summary>
        /// Gets or Sets SessionId
        /// </summary>
        [JsonPropertyName("session_id")]
        public Guid? SessionId { get; set; }

        /// <summary>
        /// Gets or Sets AvailableFrom
        /// </summary>
        [JsonPropertyName("available_from")]
        public DateTime? AvailableFrom { get; set; }

        /// <summary>
        /// Gets or Sets AvailableTo
        /// </summary>
        [JsonPropertyName("available_to")]
        public DateTime? AvailableTo { get; set; }

        /// <summary>
        /// Gets or Sets SendNotifications
        /// </summary>
        [JsonPropertyName("send_notifications")]
        public bool? SendNotifications { get; set; }

        /// <summary>
        /// Gets or Sets IsFinished
        /// </summary>
        [JsonPropertyName("is_finished")]
        public string IsFinished { get; set; }
    }
}
