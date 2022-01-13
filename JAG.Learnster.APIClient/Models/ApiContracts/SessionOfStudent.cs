using System.Text.Json.Serialization;

namespace JAG.Learnster.APIClient.Models.ApiContracts
{
    /// <summary>
    /// PublicSessionOfStudent
    /// </summary>
    public class SessionOfStudent
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
        /// Gets or Sets Progress
        /// </summary>
        [JsonPropertyName("progress")]
        public decimal? Progress { get; set; }

        /// <summary>
        /// Gets or Sets Passed
        /// </summary>
        [JsonPropertyName("passed")]
        public string Passed { get; set; }
    }
}
