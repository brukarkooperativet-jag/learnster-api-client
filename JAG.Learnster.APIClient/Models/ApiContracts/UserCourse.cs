using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// UserCourse
    /// </summary>
    public class UserCourse
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
        /// Gets or Sets NumberOfSessions
        /// </summary>
        [JsonPropertyName("number_of_sessions")]
        public int NumberOfSessions { get; set; }

        /// <summary>
        /// Gets or Sets TrackProgress
        /// </summary>
        [JsonPropertyName("track_progress")]
        public bool? TrackProgress { get; set; }
    }
}
