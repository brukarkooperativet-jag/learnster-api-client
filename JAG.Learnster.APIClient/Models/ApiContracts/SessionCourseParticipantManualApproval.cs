using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionCourseParticipantManualApproval
    /// </summary>
    public class SessionCourseParticipantManualApproval
    {
        /// <summary>
        /// Gets or Sets NotExist
        /// </summary>
        [JsonPropertyName("not_exist")]
        public List<Guid?> NotExist { get; set; }

        /// <summary>
        /// Gets or Sets Failed
        /// </summary>
        [JsonPropertyName("failed")]
        public List<Guid?> Failed { get; set; }

        /// <summary>
        /// Gets or Sets Success
        /// </summary>
        [JsonPropertyName("success")]
        public List<Guid?> Success { get; set; }

        /// <summary>
        /// Gets or Sets SendNotifications
        /// </summary>
        [JsonPropertyName("send_notifications")]
        public bool? SendNotifications { get; set; }
    }
}
