using System;
using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Converters;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// VendorSessionShortSerializerWithAvatar
    /// </summary>
    public class SessionShortWithAvatar
    {
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [JsonPropertyName("format")]
        [JsonConverter(typeof(CustomizableJsonStringEnumConverter<SessionFormat?>))]
        public SessionFormat? Format { get; set; }
        
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
        /// Gets or Sets Active
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>
        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or Sets MinParticipants
        /// </summary>
        [JsonPropertyName("min_participants")]
        public int? MinParticipants { get; set; }

        /// <summary>
        /// Gets or Sets MaxParticipants
        /// </summary>
        [JsonPropertyName("max_participants")]
        public int? MaxParticipants { get; set; }


        /// <summary>
        /// Gets or Sets Avatar
        /// </summary>
        [JsonPropertyName("avatar")]
        public ImageAssetAttachment Avatar { get; set; }

        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        [JsonPropertyName("settings")]
        public SessionSettings Settings { get; set; }

        /// <summary>
        /// Gets or Sets Course
        /// </summary>
        [JsonPropertyName("course")]
        public CourseMinimal Course { get; set; }

        /// <summary>
        /// Gets or Sets Catalog
        /// </summary>
        [JsonPropertyName("catalog")]
        public bool? Catalog { get; set; }

        /// <summary>
        /// Gets or Sets Statistics
        /// </summary>
        [JsonPropertyName("statistics")]
        public SessionStatistics Statistics { get; set; }
    }
}
