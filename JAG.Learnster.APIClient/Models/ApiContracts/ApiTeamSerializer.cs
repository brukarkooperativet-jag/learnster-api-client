using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicAPITeamSerializer
    /// </summary>
    public class ApiTeamSerializer
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [JsonPropertyName("created_date")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets CoverImage
        /// </summary>
        [JsonPropertyName("cover_image")]
        public string CoverImage { get; set; }

        /// <summary>
        /// Gets or Sets UsersCount
        /// </summary>
        [JsonPropertyName("users_count")]
        public int? UsersCount { get; set; }

        /// <summary>
        /// Gets or Sets AllowDiscussion
        /// </summary>
        [JsonPropertyName("allow_discussion")]
        public bool? AllowDiscussion { get; set; }

        /// <summary>
        /// Gets or Sets ControlledByIntegration
        /// </summary>
        [JsonPropertyName("controlled_by_integration")]
        public bool? ControlledByIntegration { get; set; }

        // TODO: FIX ME
        // /// <summary>
        // /// Gets or Sets CustomAttributes
        // /// </summary>
        // [JsonPropertyName("custom_attributes")]
        // public CustomAttributes CustomAttributes { get; set; }

        /// <summary>
        /// Gets or Sets SummaryProgress
        /// </summary>
        [JsonPropertyName("summary_progress")]
        public string SummaryProgress { get; set; }
    }
}
