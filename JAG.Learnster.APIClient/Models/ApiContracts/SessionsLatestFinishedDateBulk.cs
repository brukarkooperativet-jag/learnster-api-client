using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionsLatestFinishedDateBulk
    /// </summary>
    public class SessionsLatestFinishedDateBulk
    {
        /// <summary>
        /// Gets or Sets SessionsIds
        /// </summary>
        [JsonPropertyName("sessions_ids")]
        public List<Guid?> SessionsIds { get; set; }

        /// <summary>
        /// Gets or Sets CourseParticipants
        /// </summary>
        [JsonPropertyName("course_participants")]
        public List<CourseParticipantLatestFinishedDate> CourseParticipants { get; set; }
    }
}
