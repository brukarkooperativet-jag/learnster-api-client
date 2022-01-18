using System;
using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// VendorTagListSerializer
    /// </summary>
    public class VendorTagListSerializer
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonPropertyName("type")]
        public TagTypeEnum? Type { get; set; }
        
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
        /// Gets or Sets UsersCount
        /// </summary>
        [JsonPropertyName("users_count")]
        public int? UsersCount { get; set; }

        /// <summary>
        /// Gets or Sets EntitiesCount
        /// </summary>
        [JsonPropertyName("entities_count")]
        public int? EntitiesCount { get; set; }

        /// <summary>
        /// Gets or Sets SessionsCount
        /// </summary>
        [JsonPropertyName("sessions_count")]
        public int? SessionsCount { get; set; }

        /// <summary>
        /// Gets or Sets InvitationLinksCount
        /// </summary>
        [JsonPropertyName("invitation_links_count")]
        public int? InvitationLinksCount { get; set; }

        /// <summary>
        /// Gets or Sets ControlledByIntegration
        /// </summary>
        [JsonPropertyName("controlled_by_integration")]
        public bool? ControlledByIntegration { get; set; }
    }
}
