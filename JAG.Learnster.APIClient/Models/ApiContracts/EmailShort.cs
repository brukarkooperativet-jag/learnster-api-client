using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicEmailShort
    /// </summary>
    public class EmailShort
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets IsSendingEmailEnabled
        /// </summary>
        [JsonPropertyName("is_sending_email_enabled")]
        public bool? IsSendingEmailEnabled { get; set; }

        /// <summary>
        /// Gets or Sets IsPrimary
        /// </summary>
        [JsonPropertyName("is_primary")]
        public bool? IsPrimary { get; set; }
    }
}
