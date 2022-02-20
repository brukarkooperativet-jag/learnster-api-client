using System;
using System.Text.Json.Serialization;
using JAG.Learnster.APIClient.Converters;
using JAG.Learnster.APIClient.Models.Enums;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// UserSession
    /// </summary>
    public class UserSession
    {
        /// <summary>
        /// Gets or Sets CompletionCriteria
        /// </summary>
        [JsonPropertyName("completion_criteria")]
        [JsonConverter(typeof(CustomizableJsonStringEnumConverter<SessionCompletionCriteria?>))]
        public SessionCompletionCriteria? CompletionCriteria { get; set; }
        
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
        /// Gets or Sets Course
        /// </summary>
        [JsonPropertyName("course")]
        public UserCourse Course { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets CourseLengthFormat
        /// </summary>
        [JsonPropertyName("course_length_format")]
        public string CourseLengthFormat { get; set; }

        /// <summary>
        /// Gets or Sets Archive
        /// </summary>
        [JsonPropertyName("archive")]
        public bool? Archive { get; set; }
    }
}
