using System;
using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicPresignedPost
    /// </summary>
    public class PresignedPost
    {
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Fields
        /// </summary>
        [JsonPropertyName("fields")]
        public Object Fields { get; set; }
    }
}
