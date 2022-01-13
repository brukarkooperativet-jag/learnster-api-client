using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionCourseParticipantCompletionProgress
    /// </summary>
    public class SessionCourseParticipantCompletionProgress
    {
        /// <summary>
        /// Gets or Sets Ids
        /// </summary>
        [JsonPropertyName("ids")]
        public List<Guid?> Ids { get; set; }

        /// <summary>
        /// Gets or Sets Reset
        /// </summary>
        [JsonPropertyName("reset")]
        public List<ResetParticipantProgress> Reset { get; set; }

        /// <summary>
        /// Gets or Sets SendNotifications
        /// </summary>
        [JsonPropertyName("send_notifications")]
        public bool? SendNotifications { get; set; }
    }
}
