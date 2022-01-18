using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicTeamMinimal
    /// </summary>
    public class TeamMinimal
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
    }
}
