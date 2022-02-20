using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicUserSessionsBulk
    /// </summary>
    public class UserSessionsBulk
    {
        /// <summary>
        /// Gets or Sets UpdateList
        /// </summary>
        [JsonPropertyName("update_list")]
        public List<Guid?> UpdateList { get; set; }

        /// <summary>
        /// Gets or Sets RemoveList
        /// </summary>
        [JsonPropertyName("remove_list")]
        public List<Guid?> RemoveList { get; set; }

        /// <summary>
        /// Gets or Sets SendNotifications
        /// </summary>
        [JsonPropertyName("send_notifications")]
        public bool? SendNotifications { get; set; }
    }
}
