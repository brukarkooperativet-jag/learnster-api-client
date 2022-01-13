using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicRecurringCertification
    /// </summary>
    public class RecurringCertification
    {
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonPropertyName("status")]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// Gets or Sets LatestCertificationDate
        /// </summary>
        [JsonPropertyName("latest_certification_date")]
        public DateTime? LatestCertificationDate { get; set; }

        /// <summary>
        /// Gets or Sets ExpireAfter
        /// </summary>
        [JsonPropertyName("expire_after")]
        public decimal? ExpireAfter { get; set; }
    }
}
